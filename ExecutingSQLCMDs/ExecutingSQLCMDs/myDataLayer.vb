Imports System.Data
Imports System.Data.SqlClient
Imports System.Xml

Public Class myDataLayer
    Private Function getConnectionString() As String
        Return My.Settings.NORTHWNDConnectionString

    End Function

    Public Function getCustomers() As DataTable
        Dim sql As String
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim da As SqlDataAdapter
        Dim dt As New DataTable()
        sql = "select customerid, companyname from customers"
        conn = New SqlConnection(getConnectionString)
        conn.Open()
        cmd = New SqlCommand(sql, conn)
        da = New SqlDataAdapter(cmd)
        da.Fill(dt)
        conn.Close()
        Return dt
    End Function
    Public Function getStoredproc() As DataTable
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim da As SqlDataAdapter
        Dim dt As New DataTable()
        conn = New SqlConnection(getConnectionString)
        conn.Open()
        cmd = New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "Ten Most Expensive Products"
        da = New SqlDataAdapter(cmd)
        da.Fill(dt)
        conn.Close()
        Return dt

    End Function
    Public Function getSingleValue() As Integer
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim sql As String
        sql = "Select count(*) from Customers"
        conn = New SqlConnection(getConnectionString)
        cmd = New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        cmd.CommandText = sql
        Dim customerCount As Integer
        conn.Open()
        customerCount = CInt(cmd.ExecuteScalar())
        conn.Close()
        Return customerCount


    End Function
    Public Function getXML() As String
        Dim conn As SqlConnection
        Dim cmd As SqlCommand
        Dim sql As String
        sql = "Select customerID from customers for XML Auto"
        conn = New SqlConnection(getConnectionString)
        cmd = New SqlCommand()
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
