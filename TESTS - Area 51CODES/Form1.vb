Public Class Form1
    Public level_num, Ply_score As Integer
    Dim Rand As New Random
    Dim NPC_Timers(24) As Timer
    Dim NPC_buttons(24) As Button
    Dim Think_Count, NPCs_Health(24), Npc_button_GenTime(24), Npc_ShootIn_Time(24) As Integer
    Dim Enemy_Image As String
    Dim Special_Npcs, NPC_Buttons_USED(24) As Boolean
    Dim Needed_Kills, Weapon_clip, timer_count, NPCs_Killed, Ply_Health, Strength As Integer
    ' NOTE: Write subs for FAIL and FINISH.

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'HOKAYS
        Timer1.Enabled = False
        Enemy_Image = "stick.png"
        Ply_Health = 100
        HealthBar.Value = Ply_Health
        'Generate Items before loading stuff
        Generate_NPC_Items()

        'Load level info (maybe?)
        Load_Level()
        'Everything is loaded, start the timer to run compair the integers
        Think_Game.Enabled = True
    End Sub
    Private Sub Generate_NPC_Items()
        'Create all the buttons we need automaticly using arrays and loops
        Dim numb, size, x, y As Integer

        For numb = 0 To 24
            'Create a new button/picturebox
            NPC_buttons(numb) = New Button
            NPC_buttons(numb).Size = New Point(size, size)
            NPC_buttons(numb).Name = "NPC" & numb
            NPC_buttons(numb).Location = New Point(x, y)
            'Set the settings for the buttons
            NPC_buttons(numb).Cursor = Cursors.Cross
            NPC_buttons(numb).BackColor = Color.Transparent
            NPC_buttons(numb).ForeColor = Color.Red
            'It might still be clickable if its invisible
            NPC_buttons(numb).Visible = False
            NPC_buttons(numb).Enabled = False
            NPC_buttons(numb).BackgroundImageLayout = ImageLayout.Stretch

            'Now create the corosponding timers
            NPC_Timers(numb) = New Timer
            NPC_Timers(numb).Interval = 100
            NPC_Timers(numb).Enabled = False

            'Now set used bools
            NPC_Buttons_USED(numb) = False

            Me.Controls.Add(NPC_buttons(numb))
            'AddHandler (NPC_Timers(numb).Tick), AddressOf 
            AddHandler (NPC_buttons(numb).Click), AddressOf NPC_Kill_Check(numb)




            x = x + size + 1
        Next

    End Sub
    Private Sub Load_Level()
        'Load level from file
        'Most likely from the debug folder
        FileOpen(1, "AR51-level_" & level_num & ".txt")
        Dim background As String
        Dim Pos As Point
        Dim button_num As Integer

        'File set up as follows
        Input(1, PlayingField.Image)
        'BACKGROUND
        Input(1, Needed_Kills)
        'Needed kills
        For button_num = 0 To 24
            'Positions for buttons ( 0 through 24)
            '0,0 if its un used
            Input(1, Pos.X)
            Input(1, Pos.Y)
            If Pos.X <> 0 And Pos.Y <> 0 Then
                'We may want to modify this, just because there might
                'be barrels or thrown items
                NPC_buttons(button_num).Location = New Point(Pos.X, Pos.Y)

                'If the button is going to be used, set the spawn integers for it
                'We will just use 1 for now 
                Input(1, Npc_button_GenTime(button_num))
            End If
        Next

        Input(1, Special_Npcs)
        'Special NPCs (barrel chuckers?)
        FileClose(1)
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'handle moving item
        'or multiple!
        timer_count = timer_count + 1
        'Button2.Location = New Point(Button2.Location.X + timer_count, Button2.Location.Y)
        'Button2.Size = New Size(Button2.Size.Width + timer_count, Button2.Size.Height + timer_count)

    End Sub
    Private Sub NPC_Kill_Check(ByVal Button_num As Integer)
        'Check if youve hit the NPC hard enough
        Dim DMG_RANDOM, Minus_Time As Integer
        DMG_RANDOM = Rand.Next(5, Strength)
        Minus_Time = 3

        If NPCs_Health(Button_num) < 1 Then
            'Send the kill sub
            Kill_NPC(Button_num)
            'Check if the kill quota has been reached!
            Game_CHECK_Win()

        ElseIf NPCs_Health(Button_num) <= 20 Then
            'Pisses them off
            'Decrease the time untill the next attack
            If Npc_ShootIn_Time(Button_num) - Minus_Time <= Think_Count Then
                'Somethings messed up...
            Else
                'Shortin the time to attack the player
                Npc_ShootIn_Time(Button_num) = Npc_ShootIn_Time(Button_num) - Minus_Time
            End If
        End If

    End Sub

    Private Sub Think_Game_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Think_Game.Tick
        'A timer that fires rapidly and handles game events.
        Think_Count = Think_Count + 1

        'Spawning
        'Compair current time to input time
        For x = 0 To 24
            'Check the compaired times for all buttons
            If Npc_button_GenTime(x) = Think_Count Then
                'IT NEEDS TO BE SPAWNED!!!
                Spawn_NPC(x)
            End If
        Next

        'Attacking after shoot
        'Çomapir the current time to the time set after spawn
        For x = 0 To 24
            'Is it time to give the player damage?
            If Npc_ShootIn_Time(x) = Think_Count Then
                'Run damage sub, give random damage for NPC
                Attack_Player(Rand.Next(2, 11))
                'Set next attack time
                Set_Attack_Time(x)
            End If
        Next



    End Sub
    Private Sub Spawn_NPC(ByVal Button_num As Integer)
        'Its the NPCs time to reveal itself
        NPC_buttons(Button_num).Enabled = True
        NPC_buttons(Button_num).Visible = True
        NPC_buttons(Button_num).BackgroundImage = New Bitmap(Enemy_Image)
        'So now its up!
        'Have it start shooting?
        Set_Attack_Time(Button_num)

        'Set the npc health
        NPCs_Health(Button_num) = 150

    End Sub
    Private Sub Kill_NPC(ByVal Button_num As Integer)
        'Conveinece sub to kill the NPCS
        'Stop Animating or whatever
        NPC_buttons(Button_num).Enabled = False
        NPC_buttons(Button_num).Visible = False
        'Report a kill
        Needed_Kills = Needed_Kills - 1

    End Sub

    Private Sub Set_Attack_Time(ByVal Button_num As Integer)
        'A conveinence sub for setting and reseting an NPCs attack time
        Npc_ShootIn_Time(Button_num) = Think_Count + 5
    End Sub

    Private Sub Attack_Player(ByVal Damage As Integer)
        'Damage the player in some way
        Ply_Health = Ply_Health - Damage
        'Update the health bar
        HealthBar.Value = Ply_Health

        'If the players At or below 0 health
        'They Lose

    End Sub

    'May be uneeded if random times are not used
    Private Sub Forge_NPCs()
        'Create NPCs by highly random chance (because its on think)
        Dim Gamble As Integer
        'If we add difficulty settings we should make the max a public var
        'to be set at main menu
        Gamble = Rand.Next(1, 150)

        If Gamble = 67 Or Gamble = 12 Then
            'Then the filter has passed
            'Create a generic NPC
            'Find un-used buttons
            For x = 0 To 24
                If NPC_Buttons_USED(x) = False Then
                    'Use it and set used
                    'NPC_buttons(x).

                    'Set unusable
                    NPC_Buttons_USED(x) = True
                End If
            Next

            'Set equal to current time, so it can be compaired in the future
            'To see if the npc should shoot
            'Not sure what to set it equal to...
            'Npc_button_GenTime(numb) = 

        ElseIf Gamble = 42 And Special_Npcs = True Then
            'Create a special NPC
            'lol barrel thrower?

        End If

    End Sub
    'VB generated Stub, for file open. Might not be needed?
    Private Sub FileOpen(ByVal p1 As Integer, ByVal p2 As String)
        Throw New NotImplementedException
    End Sub

    Private Sub PlayingField_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayingField.Click
        'If the player clicks the background, clearly they missed
        Update_Clip(1)
    End Sub
    Private Sub Update_Clip(ByVal Take As Integer)
        'Update the weapon clip
        'Use a negative number to add to clip
        If Weapon_clip > 0 Then
            Weapon_clip = Weapon_clip - 1
        Else
            'Reload?
        End If

    End Sub

    Private Sub Game_CHECK_Win()
        'Check if the player has won,
        If Needed_Kills <= 0 And Ply_Health > 0 Then
            'Cool the kill quota has been reached
            'Move along
            Game_Finished()
        End If
    End Sub

    Private Sub Game_Fail()
        'Player failed
        MsgBox("FAILURE...")
        Think_Game.Stop()
        Think_Game.Enabled = False
        Timer1.Stop()
        Timer1.Enabled = False

        Me.Close()
        Form2.Visible = True

    End Sub
    Private Sub Game_Finished()
        'Player won
        MsgBox("Round complete! Time: " & Think_Count & "!")

    End Sub
    Private Sub Game_clear()
        'Really its just closing and reopening the form


    End Sub
End Class
