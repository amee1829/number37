﻿Imports MySql.Data.MySqlClient

Public Class NewStudent

    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub OK_Click(sender As Object, e As EventArgs) Handles AddBtn.Click

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
            "server = 127.0.0.1; userid = root; password = password; database = sims"
        Dim READER As MySqlDataReader

        Try
            MysqlConn.Open()

            Dim Query1 As String
            Query1 = "INSERT INTO sims.Student_Data
                        VALUES ('" & CInt(StudentID.Text) & "', '" & Password.Text & "', '" & FirstNametxt.Text & "', '" & LastNametxt.Text & "', 
                                '" & Addresstxt.Text & "', '" & Citytxt.Text & "', '" & CInt(Ziptxt.Text) & "', 
                                '" & Phonetxt.Text & "', '" & DOBtxt.Text & "', '" & SSNtxt.Text & "');"

            COMMAND = New MySqlCommand(Query1, MysqlConn)
            READER = COMMAND.ExecuteReader

            COMMAND.Dispose()
            READER.Dispose()

            Dim Query2 As String
            Query2 = "INSERT INTO sims.Grade_Record
                        VALUES('" & StudentID.Text & "', 'NotEnrolled', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)"

            COMMAND = New MySqlCommand(Query2, MysqlConn)
            READER = COMMAND.ExecuteReader

            COMMAND.Dispose()
            READER.Dispose()

            Dim Query3 As String
            Query3 = "INSERT INTO SIMS.Student_Schedule
                        VALUES('" & StudentID.Text & "', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);"

            COMMAND = New MySqlCommand(Query3, MysqlConn)
            READER = COMMAND.ExecuteReader

            COMMAND.Dispose()
            READER.Dispose()

            Dim Query4 As String
            Query4 = "INSERT INTO sims.GPA_Data
                        VALUES ('" & StudentID.Text & "', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);"

            COMMAND = New MySqlCommand(Query4, MysqlConn)
            READER = COMMAND.ExecuteReader

            COMMAND.Dispose()
            READER.Dispose()

            MessageBox.Show("Student Added!")

            MysqlConn.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try

    End Sub

    Private Sub NewStudent_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub NewStudent_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        Me.Dispose()
        Admin.Show()
    End Sub

    Private Sub NewStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub
End Class