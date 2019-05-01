'***************************************************************
'**  Program Name:   VB.NET MP3!					          **
'**  Version Number: V1.0                                     **
'**  Copyright (C):  August 9, 2009 Richard W. Allen		  **
'**	 Date Started:   August 1, 2009                           **
'**  Date Ended:     August 9, 2009                           **
'**  Author:         Richardn W. Allen                        **
'**  Webpage:        http://richard-allen.homelinux.com		  **
'**  IDE:            Micosoft Visual Stuido .NET 2008         **
'**  Compiler:       VB.NET 2008                              **
'**  Langage:        VB.NET									  **
'**	 License:		 GNU GENERAL PUBLIC LICENSE Version 2	  **
'**					 see license.txt for for details	      **
'***************************************************************/

'Used in this file
Imports System                                  'Used in all files
'Not Used here
Imports System.Windows.Forms                    'Used in frmMain.cs fromAbout.cs and AudioCode.cs
Imports System.IO                               'Used in frmMain.cs
Imports Microsoft.DirectX.AudioVideoPlayback    'Used in AudioCode.cs

Namespace Main
    Public Class Main
        Shared Sub Main()
            Dim MainForm As frmMain.frmMain = New frmMain.frmMain()
            Application.Run(MainForm)
        End Sub
    End Class
End Namespace