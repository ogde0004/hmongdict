// MainDlg.cpp : implementation of the CMainDlg class
//
/////////////////////////////////////////////////////////////////////////////

#include "stdafx.h"
#include "resource.h"

#include "MainDlg.h"
#include "sqlite3provider.h"

LRESULT CMainDlg::OnInitDialog(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& /*bHandled*/)
{
	// center the dialog on the screen
	CenterWindow();

	// set icons
	HICON hIcon = AtlLoadIconImage(IDR_MAINFRAME, LR_DEFAULTCOLOR, ::GetSystemMetrics(SM_CXICON), ::GetSystemMetrics(SM_CYICON));
	SetIcon(hIcon, TRUE);
	HICON hIconSmall = AtlLoadIconImage(IDR_MAINFRAME, LR_DEFAULTCOLOR, ::GetSystemMetrics(SM_CXSMICON), ::GetSystemMetrics(SM_CYSMICON));
	SetIcon(hIconSmall, FALSE);

	return TRUE;
}

LRESULT CMainDlg::OnAppAbout(WORD /*wNotifyCode*/, WORD /*wID*/, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	CSimpleDialog<IDD_ABOUTBOX, FALSE> dlg;
	dlg.DoModal();
	return 0;
}

#include "sqlite3provider.h"
#include "CodingConv.h"
LRESULT CMainDlg::OnOK(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	// TODO: Add validation code

	SQLiteConnection connection("C:\\Users\\Hmong\\SQLite\\Database\\Data.db");//Database.db
	connection.open();

	SetWindowTextA(this->m_hWnd, connection.version.c_str());
	{
		string cmdText = "SELECT * FROM [_Data]";//Config
		SQLiteCommand myCmd(connection);
		myCmd.setCommandText(cmdText);

		std::string text;
		std::string ColumnText;
		std::string CellText;
		char ww[512];
		const SQLiteDataReader reader = myCmd.executeReader();
		while(reader.read())
		{
			int nCount = reader.getFieldCount();
			text = "";

			for (int i=0; i<nCount; i++)
			{
				ColumnText = reader.getFieldName(i);
				CCodingConv::UTF8_2_GB2312(ww, 512, reader.getString(i).c_str());
				CellText = ww;

				text += ColumnText;
				text += ": ";
				text += CellText;
				text += "\r\n";
			}

			//m_strOutPut += text.c_str();
			//m_strOutPut += "***************************************\r\n";
		}
	}

	connection.close();

	//EndDialog(wID);
	return 0;
}

LRESULT CMainDlg::OnCancel(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& /*bHandled*/)
{
	EndDialog(wID);
	return 0;
}
