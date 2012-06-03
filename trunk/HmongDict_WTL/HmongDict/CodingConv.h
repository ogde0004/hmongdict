// CodingConv.h: interface for the CCodingConv class.
//
//////////////////////////////////////////////////////////////////////

/*
功能：汉字GB2312与UTF-8编码互转
用途：一些流行的XML解析器都不支持gb2312编码方式，但支持UTF-8编码方式，
      因此需要能够将gb2312编码转换为UTF-8的代码，见CCodingConv
作者：Medie
Email:mycro@163.com
参考：李天助先生的文章《UTF-8与GB2312之间的互换的改进》
http://www.vckbase.com/document/viewdoc/?id=1444
*/

#if !defined(CODINGCONV_H__INCLUDED_)
#define CODINGCONV_H__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

class CCodingConv  
{
public:
	// buf     - 目标缓冲区
	// buf_len - 目标缓冲区尺寸
	// src     - 原始码
	// 返回值为转换后的目标字节数
	static int GB2312_2_UTF8(char * buf, int buf_len, const char * src, int src_len = 0);
	static int UTF8_2_GB2312(char * buf, int buf_len, const char * src, int src_len = 0);
	
//private:
//	CCodingConv();
//	virtual ~CCodingConv();

};

#endif // !defined(CODINGCONV_H__INCLUDED_)
