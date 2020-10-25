Public Class Form2

    Private Sub QuitButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitButton.Click
        'Quit
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Start Game

        'Transfer values to the game form


        'Hide Current form, Show the other
        Me.Visible = False
        Form1.Visible = True
    End Sub

    Friend Sub Restart_Form(ByVal Current_level As Integer, ByVal Players_score)
        'Restart form 1

    End Sub
End Class