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
Imports System
Imports System.Windows.Forms                    'Used the make this class a form.
Imports Microsoft.DirectX.AudioVideoPlayback    'Used the Audio class from directshow 9.

Namespace AudioCode
    Public Class AudioCode
        'Member objects/variables.
        'private.
        Private my_mp3 As Audio     'Audio is the DX class for DirectShow 9.

        'Used to store the directory and filename of the file.
        Private my_dir As String = "\0"
        Private my_fileName As String = "\0"

        'Used to store the status of auto run.
        Private my_autorun As Boolean = True
        Private my_paused As Boolean = False
        Private my_play As Boolean = False
        Private my_loaded As Boolean = False

        Private my_position As Double = 0.0
        Private my_duration As Double = 0.0

        Public Sub Play()
            Try
                If my_mp3.Playing = False Then
                    my_mp3.Play()
                End If
            Catch
                MessageBox.Show("There was an error! When try to Play " + my_fileName + "!", "Play error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub

        Public Sub StopPlay()
            Try
                If my_loaded = True Then
                    my_mp3.Stop()
                End If
            Catch
                MessageBox.Show("There was an error! When try to Stop " + my_fileName + "!", "Stop error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub

        Public Sub Pause()
            Try
                If my_mp3.Paused = False Then
                    my_mp3.Pause()
                Else
                    my_mp3.Play()
                End If
            Catch
                MessageBox.Show("There was an error! When try to Pause " + my_fileName + "!", "Pause error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub

        Public Sub Load()
            Try
                Dim temp As String = String.Concat(my_dir, my_fileName)
                my_mp3 = New Audio(temp, my_autorun)
                my_loaded = True
            Catch
                MessageBox.Show("There was an error! When try to Load " + my_fileName + "!", "Load error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub

        Public Sub Balance(ByVal balance As Integer)
            Try
                If my_loaded = True Then
                    my_mp3.Balance = balance
                End If
            Catch
                MessageBox.Show("There was an error! When try to change the balance", "Sound balance error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub

        Public Sub Volume(ByVal volume As Integer)
            Try
                If my_loaded = True Then
                    my_mp3.Volume = volume
                End If
            Catch
                MessageBox.Show("There was an error! When try to change the volume", "Sound volume error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Try
        End Sub

        'Member objects/variables get and set.
        Public Property dir() As String
            Get
                Return my_dir
            End Get
            Set(ByVal Value As String)
                my_dir = Value
            End Set
        End Property

        Public Property filename() As String
            Get
                Return my_fileName
            End Get
            Set(ByVal Value As String)
                my_fileName = Value
            End Set
        End Property

        Public Property autorun() As Boolean
            Get
                Return my_autorun
            End Get
            Set(ByVal Value As Boolean)
                my_autorun = Value
            End Set
        End Property

        ReadOnly Property loaded() As Boolean
            Get
                Return my_loaded
            End Get
        End Property

        Public Property position() As Double
            Get
                Return my_mp3.CurrentPosition
            End Get
            Set(ByVal Value As Double)
                my_mp3.CurrentPosition = Value
            End Set
        End Property

        ReadOnly Property duration() As Double
            Get
                Return my_mp3.Duration
            End Get
        End Property

        ReadOnly Property paused() As Boolean
            Get
                Return my_mp3.Paused
            End Get
        End Property
    End Class
End Namespace
