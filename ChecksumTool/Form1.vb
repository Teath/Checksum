Imports System.IO
Imports System.Security.Cryptography

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If File.Exists(TextBox2.Text) Then
            Dim s512Arr = GetSHA512ForFile()
            Dim s256Arr = GetSHA256ForFile()
            Dim s1Arr = GetSHA1ForFile()
            TextBox1.Text = BitConverter.ToString(s512Arr).Replace("-", "")
            TextBox3.Text = Convert.ToBase64String(s512Arr)
            TextBox4.Text = Convert.ToBase64String(s256Arr)
            TextBox5.Text = BitConverter.ToString(s256Arr).Replace("-", "")
            TextBox6.Text = Convert.ToBase64String(s1Arr)
            TextBox7.Text = BitConverter.ToString(s1Arr).Replace("-", "")
        Else
            MsgBox("File does not exist!")
            Button1.Enabled = False
        End If
    End Sub

    Private Function GetSHA512ForFile() As Byte()
        Dim fileName = TextBox2.Text
        Dim fileBytes As Byte() = File.ReadAllBytes(fileName)
        Dim shaM As New SHA512Managed()
        Return shaM.ComputeHash(fileBytes)
    End Function

    Private Function GetSHA256ForFile() As Byte()
        Dim fileName = TextBox2.Text
        Dim fileBytes As Byte() = File.ReadAllBytes(fileName)
        Dim shaM As New SHA256Managed()
        Return shaM.ComputeHash(fileBytes)
    End Function

    Private Function GetSHA1ForFile() As Byte()
        Dim fileName = TextBox2.Text
        Dim fileBytes As Byte() = File.ReadAllBytes(fileName)
        Dim shaM As New SHA1Managed()
        Return shaM.ComputeHash(fileBytes)
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FileDial.ShowDialog()
    End Sub

    Private Sub FileDial_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles FileDial.FileOk
        TextBox2.Text = FileDial.FileName
        Button1.Enabled = True
    End Sub
End Class

