﻿Public Class Form1
    Delegate Sub ambildata(ByVal datanya As String)
    Private Sub ComboBox1_Click(sender As Object, e As EventArgs) Handles ComboBox1.Click
        ComboBox1.Items.Clear()
        ComboBox1.Items.AddRange(IO.Ports.SerialPort.GetPortNames)
    End Sub

    Private Sub ComboBox2_Click(sender As Object, e As EventArgs) Handles ComboBox2.Click
        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("9600")
        ComboBox2.Items.Add("19200")
        ComboBox2.Items.Add("38400")
        ComboBox2.Items.Add("115200")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SerialPort1.PortName = ComboBox1.Text
        SerialPort1.BaudRate = ComboBox2.Text
        SerialPort1.ReceivedBytesThreshold = TextBox1.Text
        SerialPort1.ReadBufferSize = TextBox2.Text
        SerialPort1.WriteBufferSize = TextBox3.Text
        SerialPort1.Open()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SerialPort1.Close()
    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        SerialPort1.WriteLine(TextBox4.Text)
    End Sub

    
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SerialPort1.WriteLine(TextBox4.Text)
    End Sub



    Private Sub SerialPort1_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        terimadata(SerialPort1.ReadExisting())
    End Sub


    Private Sub terimadata(ByVal datanya As String)
        If Me.InvokeRequired Then
            Dim x As New ambildata(AddressOf terimadata)
            Me.Invoke(x, New Object() {(datanya)})
        Else
            RichTextBox1.Text &= datanya
            RichTextBox1.SelectionStart = RichTextBox1.TextLength
            RichTextBox1.ScrollToCaret()
        End If
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class