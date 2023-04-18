Class MainWindow
    Enum State
        OA
        OV
        OW
        AV
        AW
        VW
        None
    End Enum
    Dim CurrentState As State = State.None
    Private Sub comboBox_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles comboBox.SelectionChanged
        If Not comboBox.SelectedIndex = -1 Then
            If comboBox.SelectedIndex = 0 Then
                txbxOhms.IsReadOnly = False
                txbxAmps.IsReadOnly = False
                txbxVolts.IsReadOnly = True
                txbxWatts.IsReadOnly = True
                txbxOhms.Background = SystemColors.ControlLightLightBrush
                txbxAmps.Background = SystemColors.ControlLightLightBrush
                txbxVolts.Background = SystemColors.ActiveBorderBrush
                txbxWatts.Background = SystemColors.ActiveBorderBrush
                CurrentState = State.OA
            ElseIf comboBox.SelectedIndex = 1 Then
                txbxOhms.IsReadOnly = False
                txbxAmps.IsReadOnly = True
                txbxVolts.IsReadOnly = False
                txbxWatts.IsReadOnly = True
                txbxOhms.Background = SystemColors.ControlLightLightBrush
                txbxAmps.Background = SystemColors.ActiveBorderBrush
                txbxVolts.Background = SystemColors.ControlLightLightBrush
                txbxWatts.Background = SystemColors.ActiveBorderBrush
                CurrentState = State.OV

            ElseIf comboBox.SelectedIndex = 2 Then
                txbxOhms.IsReadOnly = False
                txbxAmps.IsReadOnly = True
                txbxVolts.IsReadOnly = True
                txbxWatts.IsReadOnly = False
                txbxOhms.Background = SystemColors.ControlLightLightBrush
                txbxAmps.Background = SystemColors.ActiveBorderBrush
                txbxVolts.Background = SystemColors.ActiveBorderBrush
                txbxWatts.Background = SystemColors.ControlLightLightBrush
                CurrentState = State.OW

            ElseIf comboBox.SelectedIndex = 3 Then
                txbxOhms.IsReadOnly = True
                txbxAmps.IsReadOnly = False
                txbxVolts.IsReadOnly = False
                txbxWatts.IsReadOnly = True
                txbxOhms.Background = SystemColors.ActiveBorderBrush
                txbxAmps.Background = SystemColors.ControlLightLightBrush
                txbxVolts.Background = SystemColors.ControlLightLightBrush
                txbxWatts.Background = SystemColors.ActiveBorderBrush
                CurrentState = State.AV

            ElseIf comboBox.SelectedIndex = 4 Then
                txbxOhms.IsReadOnly = True
                txbxAmps.IsReadOnly = False
                txbxVolts.IsReadOnly = True
                txbxWatts.IsReadOnly = False
                txbxOhms.Background = SystemColors.ActiveBorderBrush
                txbxAmps.Background = SystemColors.ControlLightLightBrush
                txbxVolts.Background = SystemColors.ActiveBorderBrush
                txbxWatts.Background = SystemColors.ControlLightLightBrush
                CurrentState = State.AW

            ElseIf comboBox.SelectedIndex = 5 Then
                txbxOhms.IsReadOnly = True
                txbxAmps.IsReadOnly = True
                txbxVolts.IsReadOnly = False
                txbxWatts.IsReadOnly = False
                txbxOhms.Background = SystemColors.ActiveBorderBrush
                txbxAmps.Background = SystemColors.ActiveBorderBrush
                txbxVolts.Background = SystemColors.ControlLightLightBrush
                txbxWatts.Background = SystemColors.ControlLightLightBrush
                CurrentState = State.VW

            End If
        Else
            txbxOhms.IsReadOnly = True
            txbxAmps.IsReadOnly = True
            txbxVolts.IsReadOnly = True
            txbxWatts.IsReadOnly = True
            CurrentState = State.None
        End If
    End Sub

    Private Sub txbx_TextChanged(sender As TextBox, e As TextChangedEventArgs) Handles txbxOhms.TextChanged, txbxAmps.TextChanged, txbxVolts.TextChanged, txbxWatts.TextChanged
        If Me.IsLoaded Then
            If sender.Text.Length > 0 Then
                Try
                    Dim ohms As Decimal = Convert.ToDecimal(txbxOhms.Text)
                    Dim amps As Decimal = Convert.ToDecimal(txbxAmps.Text)
                    Dim volts As Decimal = Convert.ToDecimal(txbxVolts.Text)
                    Dim watts As Decimal = Convert.ToDecimal(txbxWatts.Text)
                    If CurrentState = State.OA Then
                        txbxVolts.Text = Convert.ToString(ohms * amps)
                        txbxWatts.Text = Convert.ToString(amps * amps * ohms)
                    ElseIf CurrentState = State.OV Then
                        txbxAmps.Text = Convert.ToString(volts / ohms)
                        txbxWatts.Text = Convert.ToString((volts * volts) / ohms)
                    ElseIf CurrentState = State.OW Then
                        txbxAmps.Text = Convert.ToString(Math.Sqrt(watts / ohms))
                        txbxVolts.Text = Convert.ToString(Math.Sqrt(watts * ohms))
                    ElseIf CurrentState = State.AV Then
                        txbxOhms.Text = Convert.ToString(volts / amps)
                        txbxWatts.Text = Convert.ToString(volts * amps)
                    ElseIf CurrentState = State.AW Then
                        txbxOhms.Text = Convert.ToString(watts / (amps * amps))
                        txbxVolts.Text = Convert.ToString(watts / amps)
                    ElseIf CurrentState = State.VW Then
                        txbxOhms.Text = Convert.ToString((volts * volts) / watts)
                        txbxAmps.Text = Convert.ToString(watts / volts)
                    End If
                Catch ex As Exception

                End Try
            End If
        End If

    End Sub

    Private Sub btnExit_Click(sender As Object, e As RoutedEventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub frm_Loaded(sender As Object, e As RoutedEventArgs)
        txbxOhms.Background = SystemColors.ActiveBorderBrush
        txbxAmps.Background = SystemColors.ActiveBorderBrush
        txbxVolts.Background = SystemColors.ActiveBorderBrush
        txbxWatts.Background = SystemColors.ActiveBorderBrush
    End Sub
End Class
