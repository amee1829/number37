Imports MySql.Data.MySqlClient

Public Class Student

    Dim MysqlConn As MySqlConnection
    Dim COMMAND As MySqlCommand

    Private Sub Close_Click(sender As Object, e As EventArgs) Handles Close.Click
        Me.Dispose()
        Application.Exit()
        Login.Show()
    End Sub

    Private Sub Student_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MysqlConn = New MySqlConnection
        MysqlConn.ConnectionString =
            "server = 127.0.0.1; userid = root; password = password; database = sims"

        Dim READER1 As MySqlDataReader
        Dim READER2 As MySqlDataReader

        Try
            MysqlConn.Open()

            Dim Query1 As String
            Query1 = "SELECT * FROM SIMS.student_data
                        WHERE Student_Id = '" & Login.Username.Text & "' ;"

            COMMAND = New MySqlCommand(Query1, MysqlConn)
            READER1 = COMMAND.ExecuteReader

            While READER1.Read
                StudentIDLBL.Text = READER1.GetInt32("Student_Id")
                NameLBL.Text = READER1.GetString("First_Name") + " " + READER1.GetString("Last_Name")
            End While
            READER1.Dispose()

            Dim Query2 As String
            Query2 = "SELECT * FROM SIMS.grade_record
                        LEFT JOIN SIMS.gpa_data
                        ON grade_record.Student_Id = gpa_data.Student_Id
                        WHERE grade_record.Student_Id = '" & Login.Username.Text & "' ;"

            COMMAND.Dispose()

            COMMAND = New MySqlCommand(Query2, MysqlConn)
            READER2 = COMMAND.ExecuteReader

            While READER2.Read
                SemesterLBL.Text = READER2.GetString("Semester")

                StudentGradeList.Items.Add("CRN 1: " + CStr(READER2.GetInt64("CRN1")) +
                                     "; Course Grade: " + CStr(READER2.GetInt64("CourseGrade_1")))
                StudentGradeList.Items.Add("Exam 1: " + CStr(READER2.GetInt64("Exam_1_1")))
                StudentGradeList.Items.Add("Exam 2: " + CStr(READER2.GetInt64("Exam_2_1")))
                StudentGradeList.Items.Add("Final: " + CStr(READER2.GetInt64("Final_1")))

                StudentGradeList.Items.Add("CRN 2: " + CStr(READER2.GetInt64("CRN2")) +
                                     "; Course Grade: " + CStr(READER2.GetInt64("CourseGrade_2")))
                StudentGradeList.Items.Add("Exam 1: " + CStr(READER2.GetInt64("Exam_1_2")))
                StudentGradeList.Items.Add("Exam 2: " + CStr(READER2.GetInt64("Exam_2_2")))
                StudentGradeList.Items.Add("Final: " + CStr(READER2.GetInt64("Final_2")))

                StudentGradeList.Items.Add("CRN 3: " + CStr(READER2.GetInt64("CRN3")) +
                                     "; Course Grade: " + CStr(READER2.GetInt64("CourseGrade_3")))
                StudentGradeList.Items.Add("Exam 1: " + CStr(READER2.GetInt64("Exam_1_3")))
                StudentGradeList.Items.Add("Exam 2: " + CStr(READER2.GetInt64("Exam_2_3")))
                StudentGradeList.Items.Add("Final: " + CStr(READER2.GetInt64("Final_3")))

                StudentGradeList.Items.Add("CRN 4: " + CStr(READER2.GetInt64("CRN4")) +
                                     "; Course Grade: " + CStr(READER2.GetInt64("CourseGrade_4")))
                StudentGradeList.Items.Add("Exam 1: " + CStr(READER2.GetInt64("Exam_1_4")))
                StudentGradeList.Items.Add("Exam 2: " + CStr(READER2.GetInt64("Exam_2_4")))
                StudentGradeList.Items.Add("Final: " + CStr(READER2.GetInt64("Final_4")))

                StudentGradeList.Items.Add("CRN 5: " + CStr(READER2.GetInt64("CRN5")) +
                                     "; Course Grade: " + CStr(READER2.GetInt64("CourseGrade_5")))
                StudentGradeList.Items.Add("Exam 1: " + CStr(READER2.GetInt64("Exam_1_5")))
                StudentGradeList.Items.Add("Exam 2: " + CStr(READER2.GetInt64("Exam_2_5")))
                StudentGradeList.Items.Add("Final: " + CStr(READER2.GetInt64("Final_5")))

                GPALBL.Text = READER2.GetInt64("GPA")

            End While
            READER2.Dispose()

            MysqlConn.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            MysqlConn.Dispose()
        End Try

    End Sub

    Private Sub Student_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    Private Sub Student_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Application.Exit()
    End Sub
End Class