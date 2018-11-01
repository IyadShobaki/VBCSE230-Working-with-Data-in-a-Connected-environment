
Public Class Form1
    Private dl As New myDataLayer

    Private Sub btnEmployeesInfo_Click(sender As Object, e As EventArgs) Handles btnEmployeesInfo.Click
        Dim dt As New DataTable
        dt = dl.getEmployees()
        DataGridView1.DataSource = dt
    End Sub

    Private Sub btnNumEmployees_Click(sender As Object, e As EventArgs) Handles btnNumEmployees.Click
        Label1.Text = dl.getNumEmployees.ToString()
    End Sub

    Private Sub btnXML_Click(sender As Object, e As EventArgs) Handles btnXML.Click
        TextBox1.Text = dl.getXML()

    End Sub
End Class
