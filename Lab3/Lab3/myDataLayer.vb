Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Public Class myDataLayer
    Private Function getConnectionString() As String
        Return My.Settings.NORTHWNDConnectionString
    End Function

    Public Function getEmployees() As DataTable
        Dim sql As String
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim da As SqlDataAdapter
        Dim dt As New DataTable()
        sql = "select FirstName,LastName,Title,BirthDate from Employees"
        conn = New SqlConnection(getConnectionString)
        conn.Open()
        cmd = New SqlCommand(sql, conn)
        da = New SqlDataAdapter(cmd)
        da.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function getNumEmployees() As Integer
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim sql As String
        sql = "select count(*) from Employees"
        conn = New SqlConnection(getConnectionString)
        cmd = New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        Dim EmployeesCount As Integer
        conn.Open()
        EmployeesCount = CInt(cmd.ExecuteScalar())
        conn.Close()
        Return EmployeesCount
    End Function
    Public Function getXML() As String
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim sql As String
        sql = "select FirstName + ' ' + LastName as FullName from Employees for XML Auto"
        conn = New SqlConnection(getConnectionString)
        cmd = New SqlCommand
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        conn.Open()
        Dim reader As XmlReader = cmd.ExecuteXmlReader()
        Dim myXML As String = ""
        reader.Read()
        Do While reader.ReadState <> Xml.ReadState.EndOfFile
            myXML += reader.ReadOuterXml().ToString() & vbCrLf
        Loop
        reader.Close()
        conn.Close()
        Return myXML
    End Function
End Class
