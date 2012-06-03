// CodingConv.h: interface for the CCodingConv class.
//
//////////////////////////////////////////////////////////////////////

/*
���ܣ�����GB2312��UTF-8���뻥ת
��;��һЩ���е�XML����������֧��gb2312���뷽ʽ����֧��UTF-8���뷽ʽ��
      �����Ҫ�ܹ���gb2312����ת��ΪUTF-8�Ĵ��룬��CCodingConv
���ߣ�Medie
Email:mycro@163.com
�ο������������������¡�UTF-8��GB2312֮��Ļ����ĸĽ���
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
	// buf     - Ŀ�껺����
	// buf_len - Ŀ�껺�����ߴ�
	// src     - ԭʼ��
	// ����ֵΪת�����Ŀ���ֽ���
	static int GB2312_2_UTF8(char * buf, int buf_len, const char * src, int src_len = 0);
	static int UTF8_2_GB2312(char * buf, int buf_len, const char * src, int src_len = 0);
	
//private:
//	CCodingConv();
//	virtual ~CCodingConv();

};

#endif // !defined(CODINGCONV_H__INCLUDED_)
