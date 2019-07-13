Private Sub CommandButton1_Click()

Dim swApp As Object
Dim Part As Object
Set swApp = CreateObject("SldWorks.Application")
swApp.Visible (True)
Set Part = swApp.NewPart()
Set Part = swApp.ActiveDoc
Part.InsertSketch
'part.SketchRectangle 0, 0, 0, 0.1, 0.1, 0, 1
'建立一个长方体,用中心和长宽值.textbox1是长，textbox2是宽。
Part.SketchManager.CreateCenterRectangle 0, 0, 0, TextBox1.Text / 1000 / 2, TextBox2.Text / 1000 / 2, 0

Part.FeatureExtrusion 1, 0, 1, 0, 0, TextBox3.Text / 1000, 0.02, 0, 0, 0, 0, 0.01745329251994, 0.01745329251994, 0, 0

Part.SelectByID "前视", "PLANE", 0, 0, 0
'Part.InsertSketch
'Part.CreateCircle 0, 0, 0, 0.02, 0.07, 0
Part.ShowNamedView2 "*等轴测 ", 7
'Part.FeatureCut4 1, 0, 0, 0, 0, 0.02, 0.02, 0, 0, 0, 0, 0.01745329251994, 0.01745329251994, 0, 0, -1, 0
Part.ViewZoomtofit2

End Sub

Private Sub CommandButton2_Click()
' ******************************************************************************
' C:\Users\Administrator\AppData\Local\Temp\swx7392\Macro1.swb - macro recorded on 07/12/19 by Administrator
' ******************************************************************************
Dim swApp As Object

Dim Part As Object
Dim boolstatus As Boolean
Dim longstatus As Long, longwarnings As Long

Set swApp = Application.SldWorks

Set Part = swApp.ActiveDoc
'Dim Xn As interger
'Dim Yn As interger
'Dim Zn As interger

Dim xSpace As Double
Dim ySpace As Double
Dim zSpace As Double



v1 = TextBox1.Text
v2 = TextBox2.Text
v3 = TextBox3.Text
v4 = TextBox4.Text
v5 = TextBox5.Text
v6 = TextBox6.Text
Xn = TextBox7.Text
Yn = TextBox8.Text
Zn = TextBox9.Text



xSpace = (v1 / 2 - v4) / (Xn - 1)

ySpace = v2 / (Yn - 1)

zSpace = v3 / (Zn - 1)

For i = 1 To TextBox9.Text 'Z向

    boolstatus = Part.Extension.SelectByRay(2.76888559604913E-02, 3.11491573832541E-02, 0, -0.577381545199981, -0.577287712085548, -0.577381545199979, 1.09468629056533E-03, 2, True, 0, 0)
    
    Part.FeatureManager.InsertRefPlane 264, zSpace * (i - 1) / 1000, 0, 0, 0, 0

    For j = 1 To TextBox8.Text 'Y向
        
        For k = 1 To TextBox7.Text 'X向
        
            Part.SketchManager.CreateArc (v4 + xSpace * (k - 1)) / 1000, (v5 - ySpace * (j - 1)) / 1000, 0#, (v4 + xSpace * (k - 1)) / 1000, (v5 - ySpace * (j - 1)) / 1000 - v6 / 1000, 0#, TextBox4.Text / 1000, v5 / 1000 + v6 / 1000, 0#, 1

            Part.SketchManager.CreateLine TextBox4.Text / 1000, TextBox5.Text / 1000 + TextBox6.Text / 1000, 0#, TextBox4.Text / 1000, TextBox5.Text / 1000 - TextBox6.Text / 1000, 0#

            Part.SketchManager.InsertSketch



    
            Next k
        Next j
    Next i
    
End Sub


Private Sub TextBox7_Change()

End Sub
