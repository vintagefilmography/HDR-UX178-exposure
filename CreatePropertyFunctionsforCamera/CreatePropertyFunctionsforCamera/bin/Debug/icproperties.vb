Imports TIS.Imaging
Imports System
' VB.NET Implemention of camera properties 
Public Module ICProperties
	
	''' <summary>
    ''' Check, whether Brightness is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Brightness_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Brightness : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e06-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Brightness is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Brightness_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Brightness : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e06-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Brightness Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Brightness value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Brightness(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Brightness : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e06-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Brightness DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Brightness : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Brightness Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Brightness value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Brightness</Returns>
	Public Function Brightness(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Brightness : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e06-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Brightness Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Brightness default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Brightness</Returns>
	Public Function Brightness_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Brightness : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e06-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Brightness Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Brightness minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Brightness</Returns>
	Public Function Brightness_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Brightness : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e06-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Brightness Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Brightness maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Brightness</Returns>
	Public Function Brightness_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Brightness : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e06-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Brightness Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Contrast is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Contrast_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Contrast : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e07-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Contrast is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Contrast_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Contrast : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e07-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Contrast Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Contrast value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Contrast(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Contrast : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e07-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Contrast DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Contrast : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Contrast Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Contrast value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Contrast</Returns>
	Public Function Contrast(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Contrast : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e07-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Contrast Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Contrast default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Contrast</Returns>
	Public Function Contrast_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Contrast : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e07-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Contrast Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Contrast minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Contrast</Returns>
	Public Function Contrast_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Contrast : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e07-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Contrast Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Contrast maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Contrast</Returns>
	Public Function Contrast_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Contrast : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e07-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Contrast Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Hue is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Hue_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Hue : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e08-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Hue is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Hue_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Hue : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e08-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Hue Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Hue value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Hue(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Hue : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e08-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Hue DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Hue : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Hue Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Hue value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Hue</Returns>
	Public Function Hue(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Hue : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e08-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Hue Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Hue default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Hue</Returns>
	Public Function Hue_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Hue : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e08-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Hue Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Hue minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Hue</Returns>
	Public Function Hue_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Hue : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e08-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Hue Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Hue maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Hue</Returns>
	Public Function Hue_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Hue : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e08-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Hue Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Saturation is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Saturation_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Saturation : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e09-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Saturation is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Saturation_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Saturation : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e09-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Saturation Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Saturation value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Saturation(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Saturation : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e09-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Saturation DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Saturation : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Saturation Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Saturation value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Saturation</Returns>
	Public Function Saturation(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Saturation : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e09-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Saturation Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Saturation default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Saturation</Returns>
	Public Function Saturation_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Saturation : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e09-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Saturation Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Saturation minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Saturation</Returns>
	Public Function Saturation_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Saturation : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e09-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Saturation Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Saturation maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Saturation</Returns>
	Public Function Saturation_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Saturation : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e09-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Saturation Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Sharpness is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Sharpness_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Sharpness : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0a-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Sharpness is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Sharpness_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Sharpness : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0a-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Sharpness Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Sharpness value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Sharpness(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Sharpness : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0a-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Sharpness DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Sharpness : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Sharpness Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Sharpness value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Sharpness</Returns>
	Public Function Sharpness(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Sharpness : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0a-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Sharpness Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Sharpness default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Sharpness</Returns>
	Public Function Sharpness_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Sharpness : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0a-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Sharpness Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Sharpness minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Sharpness</Returns>
	Public Function Sharpness_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Sharpness : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0a-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Sharpness Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Sharpness maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Sharpness</Returns>
	Public Function Sharpness_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Sharpness : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0a-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Sharpness Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Gamma is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Gamma_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gamma : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0b-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Gamma is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Gamma_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gamma : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0b-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Gamma Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Gamma value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Gamma(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gamma : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0b-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Gamma DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Gamma : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Gamma Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Gamma value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Gamma</Returns>
	Public Function Gamma(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gamma : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0b-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Gamma Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Gamma default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Gamma</Returns>
	Public Function Gamma_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gamma : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0b-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Gamma Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Gamma minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Gamma</Returns>
	Public Function Gamma_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gamma : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0b-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Gamma Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Gamma maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Gamma</Returns>
	Public Function Gamma_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gamma : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0b-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Gamma Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether WhiteBalance_Auto is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function WhiteBalance_Auto_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Auto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether WhiteBalance_Auto is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function WhiteBalance_Auto_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Auto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" WhiteBalance_Auto Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set WhiteBalance_Auto value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  WhiteBalance_Auto(ic As TIS.Imaging.ICImagingControl,  Value as Boolean)
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Auto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("WhiteBalance_Auto DevProperty is read only.")
			Else
				DevProperty.Switch = Value
			End If
		Else
            Throw new System.Exception("WhiteBalance_Auto Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get WhiteBalance_Auto value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of WhiteBalance_Auto</Returns>
	Public Function WhiteBalance_Auto(ic As TIS.Imaging.ICImagingControl ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Auto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Switch
		Else
            Throw new System.Exception("WhiteBalance_Auto Property is not supported by current device.")
		End If
		Return False
	End Function
	
	''' <summary>
    ''' Check, whether WhiteBalance_One_Push is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function WhiteBalance_One_Push_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDButtonProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_One_Push : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b57d3002-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Button)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether WhiteBalance_One_Push is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function WhiteBalance_One_Push_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDButtonProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_One_Push : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b57d3002-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Button)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" WhiteBalance_One_Push Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Push WhiteBalance_One_Push Property
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	Public Sub  WhiteBalance_One_Push(ic As TIS.Imaging.ICImagingControl )
		Dim DevProperty As VCDButtonProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_One_Push : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b57d3002-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Button)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("WhiteBalance_One_Push DevProperty is read only.")
			Else
				DevProperty.Push()
			End If
		Else
            Throw new System.Exception("WhiteBalance_One_Push Property is not supported by current device.")
		End If
	End Sub
    	
	''' <summary>
    ''' Check, whether WhiteBalance_Mode is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function WhiteBalance_Mode_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Mode : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("ab98f78d-18a6-4eb2-a556-c11010ec9df7"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether WhiteBalance_Mode is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function WhiteBalance_Mode_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Mode : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("ab98f78d-18a6-4eb2-a556-c11010ec9df7"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" WhiteBalance_Mode Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set WhiteBalance_Mode value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  WhiteBalance_Mode(ic As TIS.Imaging.ICImagingControl,  Value as String)
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Mode : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("ab98f78d-18a6-4eb2-a556-c11010ec9df7"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("WhiteBalance_Mode DevProperty is read only.")
			Else
                Dim AllowedString As String = ""
                Dim StringList As String()
                Dim i As Integer
                Dim ValueOK As Boolean = False

                StringList = DevProperty.Strings
                For i = 0 To StringList.Length - 1
                    AllowedString = AllowedString + StringList(i) + ", "
                    If Value = StringList(i) Then
                        ValueOK = True
                    End If
                Next

                If ValueOK Then
					DevProperty.String = Value
				Else
					Throw new System.Exception(System.String.Format( "WhiteBalance_Mode : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("WhiteBalance_Mode Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get WhiteBalance_Mode value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of WhiteBalance_Mode</Returns>
	Public Function WhiteBalance_Mode(ic As TIS.Imaging.ICImagingControl ) As String
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Mode : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("ab98f78d-18a6-4eb2-a556-c11010ec9df7"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			Return DevProperty.String
		Else
            Throw new System.Exception("WhiteBalance_Mode Property is not supported by current device.")
		End If
		Return ""
	End Function

	''' <summary>
    ''' Get string list of WhiteBalance_Mode.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>String list of WhiteBalance_Mode</Returns>
		Public Function WhiteBalance_Mode_GetStrings(ic As TIS.Imaging.ICImagingControl ) As String()
			Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Mode : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("ab98f78d-18a6-4eb2-a556-c11010ec9df7"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Strings
		Else
            Throw new System.Exception("WhiteBalance_Mode Property is not supported by current device.")
		End If
		Return Nothing
	End Function
	
	''' <summary>
    ''' Check, whether WhiteBalance_Auto_Preset is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function WhiteBalance_Auto_Preset_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Auto_Preset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("e5f037c5-a466-4f80-a717-3e506053274a"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether WhiteBalance_Auto_Preset is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function WhiteBalance_Auto_Preset_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Auto_Preset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("e5f037c5-a466-4f80-a717-3e506053274a"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" WhiteBalance_Auto_Preset Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set WhiteBalance_Auto_Preset value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  WhiteBalance_Auto_Preset(ic As TIS.Imaging.ICImagingControl,  Value as String)
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Auto_Preset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("e5f037c5-a466-4f80-a717-3e506053274a"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("WhiteBalance_Auto_Preset DevProperty is read only.")
			Else
                Dim AllowedString As String = ""
                Dim StringList As String()
                Dim i As Integer
                Dim ValueOK As Boolean = False

                StringList = DevProperty.Strings
                For i = 0 To StringList.Length - 1
                    AllowedString = AllowedString + StringList(i) + ", "
                    If Value = StringList(i) Then
                        ValueOK = True
                    End If
                Next

                If ValueOK Then
					DevProperty.String = Value
				Else
					Throw new System.Exception(System.String.Format( "WhiteBalance_Auto_Preset : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("WhiteBalance_Auto_Preset Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get WhiteBalance_Auto_Preset value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of WhiteBalance_Auto_Preset</Returns>
	Public Function WhiteBalance_Auto_Preset(ic As TIS.Imaging.ICImagingControl ) As String
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Auto_Preset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("e5f037c5-a466-4f80-a717-3e506053274a"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			Return DevProperty.String
		Else
            Throw new System.Exception("WhiteBalance_Auto_Preset Property is not supported by current device.")
		End If
		Return ""
	End Function

	''' <summary>
    ''' Get string list of WhiteBalance_Auto_Preset.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>String list of WhiteBalance_Auto_Preset</Returns>
		Public Function WhiteBalance_Auto_Preset_GetStrings(ic As TIS.Imaging.ICImagingControl ) As String()
			Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Auto_Preset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("e5f037c5-a466-4f80-a717-3e506053274a"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Strings
		Else
            Throw new System.Exception("WhiteBalance_Auto_Preset Property is not supported by current device.")
		End If
		Return Nothing
	End Function
	
	''' <summary>
    ''' Check, whether WhiteBalance_Temperature_Preset is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function WhiteBalance_Temperature_Preset_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Temperature_Preset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("88143b6d-a1c5-45d6-bf7f-95f6447ab1be"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether WhiteBalance_Temperature_Preset is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function WhiteBalance_Temperature_Preset_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Temperature_Preset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("88143b6d-a1c5-45d6-bf7f-95f6447ab1be"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" WhiteBalance_Temperature_Preset Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set WhiteBalance_Temperature_Preset value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  WhiteBalance_Temperature_Preset(ic As TIS.Imaging.ICImagingControl,  Value as String)
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Temperature_Preset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("88143b6d-a1c5-45d6-bf7f-95f6447ab1be"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("WhiteBalance_Temperature_Preset DevProperty is read only.")
			Else
                Dim AllowedString As String = ""
                Dim StringList As String()
                Dim i As Integer
                Dim ValueOK As Boolean = False

                StringList = DevProperty.Strings
                For i = 0 To StringList.Length - 1
                    AllowedString = AllowedString + StringList(i) + ", "
                    If Value = StringList(i) Then
                        ValueOK = True
                    End If
                Next

                If ValueOK Then
					DevProperty.String = Value
				Else
					Throw new System.Exception(System.String.Format( "WhiteBalance_Temperature_Preset : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("WhiteBalance_Temperature_Preset Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get WhiteBalance_Temperature_Preset value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of WhiteBalance_Temperature_Preset</Returns>
	Public Function WhiteBalance_Temperature_Preset(ic As TIS.Imaging.ICImagingControl ) As String
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Temperature_Preset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("88143b6d-a1c5-45d6-bf7f-95f6447ab1be"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			Return DevProperty.String
		Else
            Throw new System.Exception("WhiteBalance_Temperature_Preset Property is not supported by current device.")
		End If
		Return ""
	End Function

	''' <summary>
    ''' Get string list of WhiteBalance_Temperature_Preset.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>String list of WhiteBalance_Temperature_Preset</Returns>
		Public Function WhiteBalance_Temperature_Preset_GetStrings(ic As TIS.Imaging.ICImagingControl ) As String()
			Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Temperature_Preset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("88143b6d-a1c5-45d6-bf7f-95f6447ab1be"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Strings
		Else
            Throw new System.Exception("WhiteBalance_Temperature_Preset Property is not supported by current device.")
		End If
		Return Nothing
	End Function
	
	''' <summary>
    ''' Check, whether WhiteBalance_Temperature is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function WhiteBalance_Temperature_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Temperature : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b8d65671-94e0-4dbb-9275-0c29d4f6ba87"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether WhiteBalance_Temperature is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function WhiteBalance_Temperature_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Temperature : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b8d65671-94e0-4dbb-9275-0c29d4f6ba87"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" WhiteBalance_Temperature Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set WhiteBalance_Temperature value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  WhiteBalance_Temperature(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Temperature : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b8d65671-94e0-4dbb-9275-0c29d4f6ba87"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("WhiteBalance_Temperature DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "WhiteBalance_Temperature : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("WhiteBalance_Temperature Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get WhiteBalance_Temperature value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of WhiteBalance_Temperature</Returns>
	Public Function WhiteBalance_Temperature(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Temperature : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b8d65671-94e0-4dbb-9275-0c29d4f6ba87"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("WhiteBalance_Temperature Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get WhiteBalance_Temperature default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of WhiteBalance_Temperature</Returns>
	Public Function WhiteBalance_Temperature_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Temperature : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b8d65671-94e0-4dbb-9275-0c29d4f6ba87"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("WhiteBalance_Temperature Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get WhiteBalance_Temperature minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of WhiteBalance_Temperature</Returns>
	Public Function WhiteBalance_Temperature_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Temperature : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b8d65671-94e0-4dbb-9275-0c29d4f6ba87"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("WhiteBalance_Temperature Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get WhiteBalance_Temperature maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of WhiteBalance_Temperature</Returns>
	Public Function WhiteBalance_Temperature_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Temperature : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b8d65671-94e0-4dbb-9275-0c29d4f6ba87"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("WhiteBalance_Temperature Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether WhiteBalance_Red is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function WhiteBalance_Red_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Red : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038b-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether WhiteBalance_Red is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function WhiteBalance_Red_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Red : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038b-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" WhiteBalance_Red Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set WhiteBalance_Red value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  WhiteBalance_Red(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Red : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038b-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("WhiteBalance_Red DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "WhiteBalance_Red : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("WhiteBalance_Red Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get WhiteBalance_Red value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of WhiteBalance_Red</Returns>
	Public Function WhiteBalance_Red(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Red : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038b-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("WhiteBalance_Red Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get WhiteBalance_Red default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of WhiteBalance_Red</Returns>
	Public Function WhiteBalance_Red_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Red : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038b-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("WhiteBalance_Red Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get WhiteBalance_Red minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of WhiteBalance_Red</Returns>
	Public Function WhiteBalance_Red_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Red : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038b-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("WhiteBalance_Red Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get WhiteBalance_Red maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of WhiteBalance_Red</Returns>
	Public Function WhiteBalance_Red_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Red : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038b-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("WhiteBalance_Red Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether WhiteBalance_Green is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function WhiteBalance_Green_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Green : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("8407e480-175a-498c-8171-08bd987cc1ac"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether WhiteBalance_Green is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function WhiteBalance_Green_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Green : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("8407e480-175a-498c-8171-08bd987cc1ac"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" WhiteBalance_Green Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set WhiteBalance_Green value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  WhiteBalance_Green(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Green : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("8407e480-175a-498c-8171-08bd987cc1ac"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("WhiteBalance_Green DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "WhiteBalance_Green : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("WhiteBalance_Green Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get WhiteBalance_Green value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of WhiteBalance_Green</Returns>
	Public Function WhiteBalance_Green(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Green : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("8407e480-175a-498c-8171-08bd987cc1ac"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("WhiteBalance_Green Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get WhiteBalance_Green default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of WhiteBalance_Green</Returns>
	Public Function WhiteBalance_Green_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Green : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("8407e480-175a-498c-8171-08bd987cc1ac"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("WhiteBalance_Green Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get WhiteBalance_Green minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of WhiteBalance_Green</Returns>
	Public Function WhiteBalance_Green_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Green : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("8407e480-175a-498c-8171-08bd987cc1ac"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("WhiteBalance_Green Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get WhiteBalance_Green maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of WhiteBalance_Green</Returns>
	Public Function WhiteBalance_Green_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Green : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("8407e480-175a-498c-8171-08bd987cc1ac"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("WhiteBalance_Green Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether WhiteBalance_Blue is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function WhiteBalance_Blue_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Blue : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038a-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether WhiteBalance_Blue is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function WhiteBalance_Blue_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Blue : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038a-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" WhiteBalance_Blue Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set WhiteBalance_Blue value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  WhiteBalance_Blue(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Blue : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038a-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("WhiteBalance_Blue DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "WhiteBalance_Blue : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("WhiteBalance_Blue Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get WhiteBalance_Blue value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of WhiteBalance_Blue</Returns>
	Public Function WhiteBalance_Blue(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Blue : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038a-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("WhiteBalance_Blue Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get WhiteBalance_Blue default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of WhiteBalance_Blue</Returns>
	Public Function WhiteBalance_Blue_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Blue : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038a-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("WhiteBalance_Blue Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get WhiteBalance_Blue minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of WhiteBalance_Blue</Returns>
	Public Function WhiteBalance_Blue_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Blue : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038a-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("WhiteBalance_Blue Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get WhiteBalance_Blue maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of WhiteBalance_Blue</Returns>
	Public Function WhiteBalance_Blue_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("WhiteBalance_Blue : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038a-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("WhiteBalance_Blue Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Gain is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Gain_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gain : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Gain is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Gain_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gain : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Gain Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Gain value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Gain(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gain : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Gain DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Gain : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Gain Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Gain value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Gain</Returns>
	Public Function Gain(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gain : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Gain Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Gain default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Gain</Returns>
	Public Function Gain_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gain : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Gain Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Gain minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Gain</Returns>
	Public Function Gain_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gain : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Gain Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Gain maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Gain</Returns>
	Public Function Gain_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gain : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Gain Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Gain_Auto is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Gain_Auto_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gain_Auto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Gain_Auto is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Gain_Auto_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gain_Auto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Gain_Auto Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Gain_Auto value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Gain_Auto(ic As TIS.Imaging.ICImagingControl,  Value as Boolean)
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gain_Auto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Gain_Auto DevProperty is read only.")
			Else
				DevProperty.Switch = Value
			End If
		Else
            Throw new System.Exception("Gain_Auto Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Gain_Auto value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Gain_Auto</Returns>
	Public Function Gain_Auto(ic As TIS.Imaging.ICImagingControl ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Gain_Auto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Switch
		Else
            Throw new System.Exception("Gain_Auto Property is not supported by current device.")
		End If
		Return False
	End Function
	
	''' <summary>
    ''' Check, whether Exposure is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Exposure_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Exposure is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Exposure_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Exposure Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Exposure value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Exposure(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Exposure DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Exposure : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Exposure Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Exposure value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Exposure</Returns>
	Public Function Exposure(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Exposure Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Exposure default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Exposure</Returns>
	Public Function Exposure_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Exposure Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Exposure minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Exposure</Returns>
	Public Function Exposure_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Exposure Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Exposure maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Exposure</Returns>
	Public Function Exposure_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Exposure Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Exposure is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Exposure_Abs_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Exposure is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Exposure_Abs_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Exposure Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Exposure value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Exposure_Abs(ic As TIS.Imaging.ICImagingControl,  Value as Double)
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Exposure DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Exposure : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Exposure Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Exposure value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Exposure</Returns>
	Public Function Exposure_Abs(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Exposure Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Exposure default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Exposure</Returns>
	Public Function Exposure_Abs_Default(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Exposure Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Exposure minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Exposure</Returns>
	Public Function Exposure_Abs_Min(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Exposure Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Exposure maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Exposure</Returns>
	Public Function Exposure_Abs_Max(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Exposure Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Exposure_Auto is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Exposure_Auto_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Exposure_Auto is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Exposure_Auto_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Exposure_Auto Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Exposure_Auto value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Exposure_Auto(ic As TIS.Imaging.ICImagingControl,  Value as Boolean)
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Exposure_Auto DevProperty is read only.")
			Else
				DevProperty.Switch = Value
			End If
		Else
            Throw new System.Exception("Exposure_Auto Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Exposure_Auto value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Exposure_Auto</Returns>
	Public Function Exposure_Auto(ic As TIS.Imaging.ICImagingControl ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Switch
		Else
            Throw new System.Exception("Exposure_Auto Property is not supported by current device.")
		End If
		Return False
	End Function
	
	''' <summary>
    ''' Check, whether Exposure_Auto_Reference is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Exposure_Auto_Reference_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Reference : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038c-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Exposure_Auto_Reference is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Exposure_Auto_Reference_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Reference : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038c-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Exposure_Auto_Reference Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Exposure_Auto_Reference value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Exposure_Auto_Reference(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Reference : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038c-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Exposure_Auto_Reference DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Exposure_Auto_Reference : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Exposure_Auto_Reference Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Exposure_Auto_Reference value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Exposure_Auto_Reference</Returns>
	Public Function Exposure_Auto_Reference(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Reference : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038c-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Exposure_Auto_Reference Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Exposure_Auto_Reference default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Exposure_Auto_Reference</Returns>
	Public Function Exposure_Auto_Reference_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Reference : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038c-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Exposure_Auto_Reference Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Exposure_Auto_Reference minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Exposure_Auto_Reference</Returns>
	Public Function Exposure_Auto_Reference_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Reference : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038c-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Exposure_Auto_Reference Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Exposure_Auto_Reference maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Exposure_Auto_Reference</Returns>
	Public Function Exposure_Auto_Reference_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Reference : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038c-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Exposure_Auto_Reference Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Exposure_Auto_Max_Value is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Exposure_Auto_Max_Value_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Max_Value : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Exposure_Auto_Max_Value is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Exposure_Auto_Max_Value_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Max_Value : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Exposure_Auto_Max_Value Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Exposure_Auto_Max_Value value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Exposure_Auto_Max_Value(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Max_Value : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Exposure_Auto_Max_Value DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Exposure_Auto_Max_Value : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Exposure_Auto_Max_Value value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Exposure_Auto_Max_Value</Returns>
	Public Function Exposure_Auto_Max_Value(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Max_Value : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Exposure_Auto_Max_Value default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Exposure_Auto_Max_Value</Returns>
	Public Function Exposure_Auto_Max_Value_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Max_Value : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Exposure_Auto_Max_Value minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Exposure_Auto_Max_Value</Returns>
	Public Function Exposure_Auto_Max_Value_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Max_Value : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Exposure_Auto_Max_Value maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Exposure_Auto_Max_Value</Returns>
	Public Function Exposure_Auto_Max_Value_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Max_Value : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Exposure_Auto_Max_Value is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Exposure_Auto_Max_Value_Abs_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Max_Value : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Exposure_Auto_Max_Value is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Exposure_Auto_Max_Value_Abs_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Max_Value : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Exposure_Auto_Max_Value Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Exposure_Auto_Max_Value value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Exposure_Auto_Max_Value_Abs(ic As TIS.Imaging.ICImagingControl,  Value as Double)
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Max_Value : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Exposure_Auto_Max_Value DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Exposure_Auto_Max_Value : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Exposure_Auto_Max_Value value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Exposure_Auto_Max_Value</Returns>
	Public Function Exposure_Auto_Max_Value_Abs(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Max_Value : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Exposure_Auto_Max_Value default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Exposure_Auto_Max_Value</Returns>
	Public Function Exposure_Auto_Max_Value_Abs_Default(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Max_Value : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Exposure_Auto_Max_Value minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Exposure_Auto_Max_Value</Returns>
	Public Function Exposure_Auto_Max_Value_Abs_Min(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Max_Value : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Exposure_Auto_Max_Value maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Exposure_Auto_Max_Value</Returns>
	Public Function Exposure_Auto_Max_Value_Abs_Max(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_Auto_Max_Value : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Exposure_MaxAutoAuto is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Exposure_MaxAutoAuto_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_MaxAutoAuto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("65190390-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Exposure_MaxAutoAuto is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Exposure_MaxAutoAuto_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_MaxAutoAuto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("65190390-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Exposure_MaxAutoAuto Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Exposure_MaxAutoAuto value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Exposure_MaxAutoAuto(ic As TIS.Imaging.ICImagingControl,  Value as Boolean)
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_MaxAutoAuto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("65190390-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Exposure_MaxAutoAuto DevProperty is read only.")
			Else
				DevProperty.Switch = Value
			End If
		Else
            Throw new System.Exception("Exposure_MaxAutoAuto Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Exposure_MaxAutoAuto value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Exposure_MaxAutoAuto</Returns>
	Public Function Exposure_MaxAutoAuto(ic As TIS.Imaging.ICImagingControl ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Exposure_MaxAutoAuto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("65190390-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Switch
		Else
            Throw new System.Exception("Exposure_MaxAutoAuto Property is not supported by current device.")
		End If
		Return False
	End Function
	
	''' <summary>
    ''' Check, whether Trigger_Enable is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Trigger_Enable_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Trigger_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d57031-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Trigger_Enable is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Trigger_Enable_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Trigger_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d57031-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Trigger_Enable Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Trigger_Enable value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Trigger_Enable(ic As TIS.Imaging.ICImagingControl,  Value as Boolean)
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Trigger_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d57031-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Trigger_Enable DevProperty is read only.")
			Else
				DevProperty.Switch = Value
			End If
		Else
            Throw new System.Exception("Trigger_Enable Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Trigger_Enable value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Trigger_Enable</Returns>
	Public Function Trigger_Enable(ic As TIS.Imaging.ICImagingControl ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Trigger_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d57031-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Switch
		Else
            Throw new System.Exception("Trigger_Enable Property is not supported by current device.")
		End If
		Return False
	End Function
	
	''' <summary>
    ''' Check, whether Trigger_Software is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Trigger_Software_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDButtonProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Trigger_Software : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d57031-e43b-4366-aaeb-7a7a10b448b4"), new Guid("fdb4003c-552c-4faa-b87b-42e888d54147"), VCDGUIDs.VCDInterface_Button)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Trigger_Software is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Trigger_Software_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDButtonProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Trigger_Software : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d57031-e43b-4366-aaeb-7a7a10b448b4"), new Guid("fdb4003c-552c-4faa-b87b-42e888d54147"), VCDGUIDs.VCDInterface_Button)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Trigger_Software Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Push Trigger_Software Property
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	Public Sub  Trigger_Software(ic As TIS.Imaging.ICImagingControl )
		Dim DevProperty As VCDButtonProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Trigger_Software : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("90d57031-e43b-4366-aaeb-7a7a10b448b4"), new Guid("fdb4003c-552c-4faa-b87b-42e888d54147"), VCDGUIDs.VCDInterface_Button)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Trigger_Software DevProperty is read only.")
			Else
				DevProperty.Push()
			End If
		Else
            Throw new System.Exception("Trigger_Software Property is not supported by current device.")
		End If
	End Sub
    	
	''' <summary>
    ''' Check, whether Denoise is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Denoise_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Denoise : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("c3c9944a-e6f6-4e25-a0be-53c066ab65d8"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Denoise is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Denoise_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Denoise : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("c3c9944a-e6f6-4e25-a0be-53c066ab65d8"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Denoise Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Denoise value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Denoise(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Denoise : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("c3c9944a-e6f6-4e25-a0be-53c066ab65d8"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Denoise DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Denoise : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Denoise Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Denoise value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Denoise</Returns>
	Public Function Denoise(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Denoise : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("c3c9944a-e6f6-4e25-a0be-53c066ab65d8"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Denoise Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Denoise default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Denoise</Returns>
	Public Function Denoise_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Denoise : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("c3c9944a-e6f6-4e25-a0be-53c066ab65d8"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Denoise Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Denoise minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Denoise</Returns>
	Public Function Denoise_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Denoise : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("c3c9944a-e6f6-4e25-a0be-53c066ab65d8"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Denoise Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Denoise maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Denoise</Returns>
	Public Function Denoise_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Denoise : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("c3c9944a-e6f6-4e25-a0be-53c066ab65d8"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Denoise Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether GPIO_GP_IN is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function GPIO_GP_IN_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_GP_IN : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a500"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether GPIO_GP_IN is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function GPIO_GP_IN_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_GP_IN : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a500"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" GPIO_GP_IN Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set GPIO_GP_IN value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  GPIO_GP_IN(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_GP_IN : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a500"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("GPIO_GP_IN DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "GPIO_GP_IN : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("GPIO_GP_IN Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get GPIO_GP_IN value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of GPIO_GP_IN</Returns>
	Public Function GPIO_GP_IN(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_GP_IN : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a500"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("GPIO_GP_IN Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get GPIO_GP_IN default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of GPIO_GP_IN</Returns>
	Public Function GPIO_GP_IN_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_GP_IN : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a500"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("GPIO_GP_IN Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get GPIO_GP_IN minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of GPIO_GP_IN</Returns>
	Public Function GPIO_GP_IN_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_GP_IN : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a500"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("GPIO_GP_IN Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get GPIO_GP_IN maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of GPIO_GP_IN</Returns>
	Public Function GPIO_GP_IN_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_GP_IN : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a500"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("GPIO_GP_IN Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether GPIO_Read is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function GPIO_Read_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDButtonProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_Read : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a503"), VCDGUIDs.VCDInterface_Button)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether GPIO_Read is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function GPIO_Read_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDButtonProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_Read : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a503"), VCDGUIDs.VCDInterface_Button)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" GPIO_Read Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Push GPIO_Read Property
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	Public Sub  GPIO_Read(ic As TIS.Imaging.ICImagingControl )
		Dim DevProperty As VCDButtonProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_Read : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a503"), VCDGUIDs.VCDInterface_Button)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("GPIO_Read DevProperty is read only.")
			Else
				DevProperty.Push()
			End If
		Else
            Throw new System.Exception("GPIO_Read Property is not supported by current device.")
		End If
	End Sub
    	
	''' <summary>
    ''' Check, whether GPIO_GP_Out is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function GPIO_GP_Out_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_GP_Out : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a501"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether GPIO_GP_Out is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function GPIO_GP_Out_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_GP_Out : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a501"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" GPIO_GP_Out Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set GPIO_GP_Out value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  GPIO_GP_Out(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_GP_Out : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a501"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("GPIO_GP_Out DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "GPIO_GP_Out : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("GPIO_GP_Out Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get GPIO_GP_Out value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of GPIO_GP_Out</Returns>
	Public Function GPIO_GP_Out(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_GP_Out : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a501"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("GPIO_GP_Out Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get GPIO_GP_Out default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of GPIO_GP_Out</Returns>
	Public Function GPIO_GP_Out_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_GP_Out : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a501"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("GPIO_GP_Out Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get GPIO_GP_Out minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of GPIO_GP_Out</Returns>
	Public Function GPIO_GP_Out_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_GP_Out : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a501"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("GPIO_GP_Out Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get GPIO_GP_Out maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of GPIO_GP_Out</Returns>
	Public Function GPIO_GP_Out_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_GP_Out : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a501"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("GPIO_GP_Out Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether GPIO_Write is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function GPIO_Write_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDButtonProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_Write : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a502"), VCDGUIDs.VCDInterface_Button)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether GPIO_Write is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function GPIO_Write_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDButtonProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_Write : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a502"), VCDGUIDs.VCDInterface_Button)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" GPIO_Write Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Push GPIO_Write Property
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	Public Sub  GPIO_Write(ic As TIS.Imaging.ICImagingControl )
		Dim DevProperty As VCDButtonProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("GPIO_Write : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a502"), VCDGUIDs.VCDInterface_Button)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("GPIO_Write DevProperty is read only.")
			Else
				DevProperty.Push()
			End If
		Else
            Throw new System.Exception("GPIO_Write Property is not supported by current device.")
		End If
	End Sub
    	
	''' <summary>
    ''' Check, whether Binning_factor is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Binning_factor_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Binning_factor : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("4f95a06d-9c15-407b-96ab-cf3fed047ba4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Binning_factor is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Binning_factor_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Binning_factor : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("4f95a06d-9c15-407b-96ab-cf3fed047ba4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Binning_factor Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Binning_factor value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Binning_factor(ic As TIS.Imaging.ICImagingControl,  Value as String)
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Binning_factor : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("4f95a06d-9c15-407b-96ab-cf3fed047ba4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Binning_factor DevProperty is read only.")
			Else
                Dim AllowedString As String = ""
                Dim StringList As String()
                Dim i As Integer
                Dim ValueOK As Boolean = False

                StringList = DevProperty.Strings
                For i = 0 To StringList.Length - 1
                    AllowedString = AllowedString + StringList(i) + ", "
                    If Value = StringList(i) Then
                        ValueOK = True
                    End If
                Next

                If ValueOK Then
					DevProperty.String = Value
				Else
					Throw new System.Exception(System.String.Format( "Binning_factor : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Binning_factor Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Binning_factor value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Binning_factor</Returns>
	Public Function Binning_factor(ic As TIS.Imaging.ICImagingControl ) As String
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Binning_factor : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("4f95a06d-9c15-407b-96ab-cf3fed047ba4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			Return DevProperty.String
		Else
            Throw new System.Exception("Binning_factor Property is not supported by current device.")
		End If
		Return ""
	End Function

	''' <summary>
    ''' Get string list of Binning_factor.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>String list of Binning_factor</Returns>
		Public Function Binning_factor_GetStrings(ic As TIS.Imaging.ICImagingControl ) As String()
			Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Binning_factor : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("4f95a06d-9c15-407b-96ab-cf3fed047ba4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Strings
		Else
            Throw new System.Exception("Binning_factor Property is not supported by current device.")
		End If
		Return Nothing
	End Function
	
	''' <summary>
    ''' Check, whether Color_Enhancement_Enable is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Color_Enhancement_Enable_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Color_Enhancement_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3a3a8f77-6440-46cc-940a-8752b02e6c29"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Color_Enhancement_Enable is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Color_Enhancement_Enable_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Color_Enhancement_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3a3a8f77-6440-46cc-940a-8752b02e6c29"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Color_Enhancement_Enable Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Color_Enhancement_Enable value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Color_Enhancement_Enable(ic As TIS.Imaging.ICImagingControl,  Value as Boolean)
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Color_Enhancement_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3a3a8f77-6440-46cc-940a-8752b02e6c29"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Color_Enhancement_Enable DevProperty is read only.")
			Else
				DevProperty.Switch = Value
			End If
		Else
            Throw new System.Exception("Color_Enhancement_Enable Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Color_Enhancement_Enable value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Color_Enhancement_Enable</Returns>
	Public Function Color_Enhancement_Enable(ic As TIS.Imaging.ICImagingControl ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Color_Enhancement_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3a3a8f77-6440-46cc-940a-8752b02e6c29"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Switch
		Else
            Throw new System.Exception("Color_Enhancement_Enable Property is not supported by current device.")
		End If
		Return False
	End Function
	
	''' <summary>
    ''' Check, whether Highlight_reduction_Enable is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Highlight_reduction_Enable_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Highlight_reduction_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("546541ad-c815-4d82-afa9-9d59af9f399e"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Highlight_reduction_Enable is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Highlight_reduction_Enable_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Highlight_reduction_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("546541ad-c815-4d82-afa9-9d59af9f399e"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Highlight_reduction_Enable Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Highlight_reduction_Enable value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Highlight_reduction_Enable(ic As TIS.Imaging.ICImagingControl,  Value as Boolean)
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Highlight_reduction_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("546541ad-c815-4d82-afa9-9d59af9f399e"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Highlight_reduction_Enable DevProperty is read only.")
			Else
				DevProperty.Switch = Value
			End If
		Else
            Throw new System.Exception("Highlight_reduction_Enable Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Highlight_reduction_Enable value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Highlight_reduction_Enable</Returns>
	Public Function Highlight_reduction_Enable(ic As TIS.Imaging.ICImagingControl ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Highlight_reduction_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("546541ad-c815-4d82-afa9-9d59af9f399e"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Switch
		Else
            Throw new System.Exception("Highlight_reduction_Enable Property is not supported by current device.")
		End If
		Return False
	End Function
	
	''' <summary>
    ''' Check, whether Tone_Mapping_Enable is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Tone_Mapping_Enable_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Tone_Mapping_Enable is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Tone_Mapping_Enable_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Tone_Mapping_Enable Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Tone_Mapping_Enable value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Tone_Mapping_Enable(ic As TIS.Imaging.ICImagingControl,  Value as Boolean)
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Tone_Mapping_Enable DevProperty is read only.")
			Else
				DevProperty.Switch = Value
			End If
		Else
            Throw new System.Exception("Tone_Mapping_Enable Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Tone_Mapping_Enable value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Tone_Mapping_Enable</Returns>
	Public Function Tone_Mapping_Enable(ic As TIS.Imaging.ICImagingControl ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Switch
		Else
            Throw new System.Exception("Tone_Mapping_Enable Property is not supported by current device.")
		End If
		Return False
	End Function
	
	''' <summary>
    ''' Check, whether Tone_Mapping_Auto is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Tone_Mapping_Auto_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Auto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Tone_Mapping_Auto is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Tone_Mapping_Auto_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Auto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Tone_Mapping_Auto Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Tone_Mapping_Auto value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Tone_Mapping_Auto(ic As TIS.Imaging.ICImagingControl,  Value as Boolean)
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Auto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Tone_Mapping_Auto DevProperty is read only.")
			Else
				DevProperty.Switch = Value
			End If
		Else
            Throw new System.Exception("Tone_Mapping_Auto Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Tone_Mapping_Auto value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Tone_Mapping_Auto</Returns>
	Public Function Tone_Mapping_Auto(ic As TIS.Imaging.ICImagingControl ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Auto : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Switch
		Else
            Throw new System.Exception("Tone_Mapping_Auto Property is not supported by current device.")
		End If
		Return False
	End Function
	
	''' <summary>
    ''' Check, whether Tone_Mapping_Intensity is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Tone_Mapping_Intensity_Abs_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Intensity : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("bd2f432a-02c1-4f32-9aeb-687ca117d2e7"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Tone_Mapping_Intensity is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Tone_Mapping_Intensity_Abs_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Intensity : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("bd2f432a-02c1-4f32-9aeb-687ca117d2e7"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Tone_Mapping_Intensity Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Tone_Mapping_Intensity value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Tone_Mapping_Intensity_Abs(ic As TIS.Imaging.ICImagingControl,  Value as Double)
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Intensity : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("bd2f432a-02c1-4f32-9aeb-687ca117d2e7"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Tone_Mapping_Intensity DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Tone_Mapping_Intensity : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Tone_Mapping_Intensity Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Tone_Mapping_Intensity value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Tone_Mapping_Intensity</Returns>
	Public Function Tone_Mapping_Intensity_Abs(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Intensity : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("bd2f432a-02c1-4f32-9aeb-687ca117d2e7"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Tone_Mapping_Intensity Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Tone_Mapping_Intensity default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Tone_Mapping_Intensity</Returns>
	Public Function Tone_Mapping_Intensity_Abs_Default(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Intensity : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("bd2f432a-02c1-4f32-9aeb-687ca117d2e7"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Tone_Mapping_Intensity Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Tone_Mapping_Intensity minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Tone_Mapping_Intensity</Returns>
	Public Function Tone_Mapping_Intensity_Abs_Min(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Intensity : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("bd2f432a-02c1-4f32-9aeb-687ca117d2e7"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Tone_Mapping_Intensity Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Tone_Mapping_Intensity maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Tone_Mapping_Intensity</Returns>
	Public Function Tone_Mapping_Intensity_Abs_Max(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Intensity : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("bd2f432a-02c1-4f32-9aeb-687ca117d2e7"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Tone_Mapping_Intensity Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Tone_Mapping_Global_Brightness_Factor is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Tone_Mapping_Global_Brightness_Factor_Abs_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Global_Brightness_Factor : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("d1451fed-c2d8-42ce-910b-2cb566836a77"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Tone_Mapping_Global_Brightness_Factor is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Tone_Mapping_Global_Brightness_Factor_Abs_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Global_Brightness_Factor : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("d1451fed-c2d8-42ce-910b-2cb566836a77"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Tone_Mapping_Global_Brightness_Factor value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Tone_Mapping_Global_Brightness_Factor_Abs(ic As TIS.Imaging.ICImagingControl,  Value as Double)
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Global_Brightness_Factor : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("d1451fed-c2d8-42ce-910b-2cb566836a77"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Tone_Mapping_Global_Brightness_Factor DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Tone_Mapping_Global_Brightness_Factor : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Tone_Mapping_Global_Brightness_Factor value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Tone_Mapping_Global_Brightness_Factor</Returns>
	Public Function Tone_Mapping_Global_Brightness_Factor_Abs(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Global_Brightness_Factor : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("d1451fed-c2d8-42ce-910b-2cb566836a77"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Tone_Mapping_Global_Brightness_Factor default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Tone_Mapping_Global_Brightness_Factor</Returns>
	Public Function Tone_Mapping_Global_Brightness_Factor_Abs_Default(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Global_Brightness_Factor : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("d1451fed-c2d8-42ce-910b-2cb566836a77"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Tone_Mapping_Global_Brightness_Factor minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Tone_Mapping_Global_Brightness_Factor</Returns>
	Public Function Tone_Mapping_Global_Brightness_Factor_Abs_Min(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Global_Brightness_Factor : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("d1451fed-c2d8-42ce-910b-2cb566836a77"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Tone_Mapping_Global_Brightness_Factor maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Tone_Mapping_Global_Brightness_Factor</Returns>
	Public Function Tone_Mapping_Global_Brightness_Factor_Abs_Max(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_Global_Brightness_Factor : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("d1451fed-c2d8-42ce-910b-2cb566836a77"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Tone_Mapping_a is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Tone_Mapping_a_Abs_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_a : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Tone_Mapping_a is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Tone_Mapping_a_Abs_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_a : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Tone_Mapping_a Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Tone_Mapping_a value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Tone_Mapping_a_Abs(ic As TIS.Imaging.ICImagingControl,  Value as Double)
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_a : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Tone_Mapping_a DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Tone_Mapping_a : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Tone_Mapping_a Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Tone_Mapping_a value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Tone_Mapping_a</Returns>
	Public Function Tone_Mapping_a_Abs(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_a : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Tone_Mapping_a Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Tone_Mapping_a default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Tone_Mapping_a</Returns>
	Public Function Tone_Mapping_a_Abs_Default(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_a : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Tone_Mapping_a Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Tone_Mapping_a minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Tone_Mapping_a</Returns>
	Public Function Tone_Mapping_a_Abs_Min(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_a : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Tone_Mapping_a Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Tone_Mapping_a maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Tone_Mapping_a</Returns>
	Public Function Tone_Mapping_a_Abs_Max(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_a : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Tone_Mapping_a Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Tone_Mapping_b is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Tone_Mapping_b_Abs_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_b : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("8a1a5755-a562-470b-9842-97b08791144c"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Tone_Mapping_b is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Tone_Mapping_b_Abs_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_b : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("8a1a5755-a562-470b-9842-97b08791144c"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Tone_Mapping_b Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Tone_Mapping_b value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Tone_Mapping_b_Abs(ic As TIS.Imaging.ICImagingControl,  Value as Double)
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_b : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("8a1a5755-a562-470b-9842-97b08791144c"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Tone_Mapping_b DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Tone_Mapping_b : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Tone_Mapping_b Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Tone_Mapping_b value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Tone_Mapping_b</Returns>
	Public Function Tone_Mapping_b_Abs(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_b : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("8a1a5755-a562-470b-9842-97b08791144c"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Tone_Mapping_b Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Tone_Mapping_b default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Tone_Mapping_b</Returns>
	Public Function Tone_Mapping_b_Abs_Default(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_b : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("8a1a5755-a562-470b-9842-97b08791144c"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Tone_Mapping_b Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Tone_Mapping_b minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Tone_Mapping_b</Returns>
	Public Function Tone_Mapping_b_Abs_Min(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_b : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("8a1a5755-a562-470b-9842-97b08791144c"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Tone_Mapping_b Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Tone_Mapping_b maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Tone_Mapping_b</Returns>
	Public Function Tone_Mapping_b_Abs_Max(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_b : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("8a1a5755-a562-470b-9842-97b08791144c"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Tone_Mapping_b Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Tone_Mapping_c is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Tone_Mapping_c_Abs_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_c : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("e6d1fed4-c28a-431d-b9ec-0fce3566235a"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Tone_Mapping_c is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Tone_Mapping_c_Abs_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_c : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("e6d1fed4-c28a-431d-b9ec-0fce3566235a"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Tone_Mapping_c Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Tone_Mapping_c value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Tone_Mapping_c_Abs(ic As TIS.Imaging.ICImagingControl,  Value as Double)
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_c : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("e6d1fed4-c28a-431d-b9ec-0fce3566235a"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Tone_Mapping_c DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Tone_Mapping_c : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Tone_Mapping_c Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Tone_Mapping_c value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Tone_Mapping_c</Returns>
	Public Function Tone_Mapping_c_Abs(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_c : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("e6d1fed4-c28a-431d-b9ec-0fce3566235a"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Tone_Mapping_c Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Tone_Mapping_c default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Tone_Mapping_c</Returns>
	Public Function Tone_Mapping_c_Abs_Default(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_c : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("e6d1fed4-c28a-431d-b9ec-0fce3566235a"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Tone_Mapping_c Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Tone_Mapping_c minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Tone_Mapping_c</Returns>
	Public Function Tone_Mapping_c_Abs_Min(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_c : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("e6d1fed4-c28a-431d-b9ec-0fce3566235a"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Tone_Mapping_c Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Tone_Mapping_c maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Tone_Mapping_c</Returns>
	Public Function Tone_Mapping_c_Abs_Max(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_c : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("e6d1fed4-c28a-431d-b9ec-0fce3566235a"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Tone_Mapping_c Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Tone_Mapping_lum_avg is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Tone_Mapping_lum_avg_Abs_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_lum_avg : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("0634aea5-2a19-4292-97bc-7d228ae4c60f"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Tone_Mapping_lum_avg is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Tone_Mapping_lum_avg_Abs_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_lum_avg : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("0634aea5-2a19-4292-97bc-7d228ae4c60f"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Tone_Mapping_lum_avg Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Tone_Mapping_lum_avg value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Tone_Mapping_lum_avg_Abs(ic As TIS.Imaging.ICImagingControl,  Value as Double)
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_lum_avg : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("0634aea5-2a19-4292-97bc-7d228ae4c60f"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Tone_Mapping_lum_avg DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Tone_Mapping_lum_avg : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Tone_Mapping_lum_avg Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Tone_Mapping_lum_avg value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Tone_Mapping_lum_avg</Returns>
	Public Function Tone_Mapping_lum_avg_Abs(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_lum_avg : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("0634aea5-2a19-4292-97bc-7d228ae4c60f"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Tone_Mapping_lum_avg Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Tone_Mapping_lum_avg default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Tone_Mapping_lum_avg</Returns>
	Public Function Tone_Mapping_lum_avg_Abs_Default(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_lum_avg : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("0634aea5-2a19-4292-97bc-7d228ae4c60f"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Tone_Mapping_lum_avg Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Tone_Mapping_lum_avg minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Tone_Mapping_lum_avg</Returns>
	Public Function Tone_Mapping_lum_avg_Abs_Min(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_lum_avg : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("0634aea5-2a19-4292-97bc-7d228ae4c60f"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Tone_Mapping_lum_avg Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Tone_Mapping_lum_avg maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Tone_Mapping_lum_avg</Returns>
	Public Function Tone_Mapping_lum_avg_Abs_Max(ic As TIS.Imaging.ICImagingControl ) As Double
		Dim DevProperty As VCDAbsoluteValueProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Tone_Mapping_lum_avg : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("0634aea5-2a19-4292-97bc-7d228ae4c60f"), VCDGUIDs.VCDInterface_AbsoluteValue)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Tone_Mapping_lum_avg Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Partial_scan_Auto_center is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Partial_scan_Auto_center_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_Auto_center : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("36eaa683-3321-44be-9d73-e1fd4c3fdb87"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Partial_scan_Auto_center is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Partial_scan_Auto_center_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_Auto_center : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("36eaa683-3321-44be-9d73-e1fd4c3fdb87"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Partial_scan_Auto_center Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Partial_scan_Auto_center value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Partial_scan_Auto_center(ic As TIS.Imaging.ICImagingControl,  Value as Boolean)
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_Auto_center : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("36eaa683-3321-44be-9d73-e1fd4c3fdb87"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Partial_scan_Auto_center DevProperty is read only.")
			Else
				DevProperty.Switch = Value
			End If
		Else
            Throw new System.Exception("Partial_scan_Auto_center Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Partial_scan_Auto_center value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Partial_scan_Auto_center</Returns>
	Public Function Partial_scan_Auto_center(ic As TIS.Imaging.ICImagingControl ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_Auto_center : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("36eaa683-3321-44be-9d73-e1fd4c3fdb87"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Switch
		Else
            Throw new System.Exception("Partial_scan_Auto_center Property is not supported by current device.")
		End If
		Return False
	End Function
	
	''' <summary>
    ''' Check, whether Partial_scan_X_Offset is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Partial_scan_X_Offset_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_X_Offset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("5e59f654-7b47-4458-b4c6-5d4f0d175fc1"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Partial_scan_X_Offset is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Partial_scan_X_Offset_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_X_Offset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("5e59f654-7b47-4458-b4c6-5d4f0d175fc1"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Partial_scan_X_Offset Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Partial_scan_X_Offset value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Partial_scan_X_Offset(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_X_Offset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("5e59f654-7b47-4458-b4c6-5d4f0d175fc1"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Partial_scan_X_Offset DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Partial_scan_X_Offset : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Partial_scan_X_Offset Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Partial_scan_X_Offset value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Partial_scan_X_Offset</Returns>
	Public Function Partial_scan_X_Offset(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_X_Offset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("5e59f654-7b47-4458-b4c6-5d4f0d175fc1"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Partial_scan_X_Offset Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Partial_scan_X_Offset default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Partial_scan_X_Offset</Returns>
	Public Function Partial_scan_X_Offset_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_X_Offset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("5e59f654-7b47-4458-b4c6-5d4f0d175fc1"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Partial_scan_X_Offset Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Partial_scan_X_Offset minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Partial_scan_X_Offset</Returns>
	Public Function Partial_scan_X_Offset_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_X_Offset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("5e59f654-7b47-4458-b4c6-5d4f0d175fc1"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Partial_scan_X_Offset Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Partial_scan_X_Offset maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Partial_scan_X_Offset</Returns>
	Public Function Partial_scan_X_Offset_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_X_Offset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("5e59f654-7b47-4458-b4c6-5d4f0d175fc1"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Partial_scan_X_Offset Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Partial_scan_Y_Offset is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Partial_scan_Y_Offset_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_Y_Offset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("87fb6c02-98a8-46b0-b18d-6442d9775cd3"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Partial_scan_Y_Offset is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Partial_scan_Y_Offset_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_Y_Offset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("87fb6c02-98a8-46b0-b18d-6442d9775cd3"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Partial_scan_Y_Offset Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Partial_scan_Y_Offset value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Partial_scan_Y_Offset(ic As TIS.Imaging.ICImagingControl,  Value as Integer)
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_Y_Offset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("87fb6c02-98a8-46b0-b18d-6442d9775cd3"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Partial_scan_Y_Offset DevProperty is read only.")
			Else
				If DevProperty.RangeMin <= Value And DevProperty.RangeMax >= Value Then 
					DevProperty.Value = Value
				Else
					Throw new System.Exception(System.String.Format( "Partial_scan_Y_Offset : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Partial_scan_Y_Offset Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Partial_scan_Y_Offset value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Partial_scan_Y_Offset</Returns>
	Public Function Partial_scan_Y_Offset(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_Y_Offset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("87fb6c02-98a8-46b0-b18d-6442d9775cd3"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Value
		Else
            Throw new System.Exception("Partial_scan_Y_Offset Property is not supported by current device.")
		End If
		Return 0
	End Function

	''' <summary>
    ''' Get Partial_scan_Y_Offset default value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Default value of Partial_scan_Y_Offset</Returns>
	Public Function Partial_scan_Y_Offset_Default(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_Y_Offset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("87fb6c02-98a8-46b0-b18d-6442d9775cd3"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Default
		Else
            Throw new System.Exception("Partial_scan_Y_Offset Property is not supported by current device.")
		End If
		Return 0
	End Function

		''' <summary>
    ''' Get Partial_scan_Y_Offset minimum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Minimum value of Partial_scan_Y_Offset</Returns>
	Public Function Partial_scan_Y_Offset_Min(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_Y_Offset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("87fb6c02-98a8-46b0-b18d-6442d9775cd3"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMin
		Else
            Throw new System.Exception("Partial_scan_Y_Offset Property is not supported by current device.")
		End If
		Return 0
	End Function



	''' <summary>
    ''' Get Partial_scan_Y_Offset maximum value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Maximum value of Partial_scan_Y_Offset</Returns>
	Public Function Partial_scan_Y_Offset_Max(ic As TIS.Imaging.ICImagingControl ) As Integer
		Dim DevProperty As VCDRangeProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Partial_scan_Y_Offset : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("87fb6c02-98a8-46b0-b18d-6442d9775cd3"), VCDGUIDs.VCDInterface_Range)

		If Not DevProperty Is Nothing Then
			Return DevProperty.RangeMax
		Else
            Throw new System.Exception("Partial_scan_Y_Offset Property is not supported by current device.")
		End If
		Return 0
	End Function	
	''' <summary>
    ''' Check, whether Strobe_Enable is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Strobe_Enable_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Strobe_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Strobe_Enable is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Strobe_Enable_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Strobe_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Strobe_Enable Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Strobe_Enable value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Strobe_Enable(ic As TIS.Imaging.ICImagingControl,  Value as Boolean)
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Strobe_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Strobe_Enable DevProperty is read only.")
			Else
				DevProperty.Switch = Value
			End If
		Else
            Throw new System.Exception("Strobe_Enable Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Strobe_Enable value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Strobe_Enable</Returns>
	Public Function Strobe_Enable(ic As TIS.Imaging.ICImagingControl ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Strobe_Enable : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Switch
		Else
            Throw new System.Exception("Strobe_Enable Property is not supported by current device.")
		End If
		Return False
	End Function
	
	''' <summary>
    ''' Check, whether Strobe_Mode is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Strobe_Mode_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Strobe_Mode : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580acd"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Strobe_Mode is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Strobe_Mode_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Strobe_Mode : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580acd"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Strobe_Mode Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Strobe_Mode value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Strobe_Mode(ic As TIS.Imaging.ICImagingControl,  Value as String)
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Strobe_Mode : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580acd"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Strobe_Mode DevProperty is read only.")
			Else
                Dim AllowedString As String = ""
                Dim StringList As String()
                Dim i As Integer
                Dim ValueOK As Boolean = False

                StringList = DevProperty.Strings
                For i = 0 To StringList.Length - 1
                    AllowedString = AllowedString + StringList(i) + ", "
                    If Value = StringList(i) Then
                        ValueOK = True
                    End If
                Next

                If ValueOK Then
					DevProperty.String = Value
				Else
					Throw new System.Exception(System.String.Format( "Strobe_Mode : Value {0} is not in range {1} - {2}.", Value, DevProperty.RangeMin, DevProperty.RangeMax ))
				End If
			End If
		Else
            Throw new System.Exception("Strobe_Mode Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Strobe_Mode value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Strobe_Mode</Returns>
	Public Function Strobe_Mode(ic As TIS.Imaging.ICImagingControl ) As String
		Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Strobe_Mode : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580acd"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			Return DevProperty.String
		Else
            Throw new System.Exception("Strobe_Mode Property is not supported by current device.")
		End If
		Return ""
	End Function

	''' <summary>
    ''' Get string list of Strobe_Mode.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>String list of Strobe_Mode</Returns>
		Public Function Strobe_Mode_GetStrings(ic As TIS.Imaging.ICImagingControl ) As String()
			Dim DevProperty As VCDMapStringsProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Strobe_Mode : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580acd"), VCDGUIDs.VCDInterface_MapStrings)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Strings
		Else
            Throw new System.Exception("Strobe_Mode Property is not supported by current device.")
		End If
		Return Nothing
	End Function
	
	''' <summary>
    ''' Check, whether Strobe_Polarity is available for current device.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true : Available, false: not available</Returns>
	Public Function Strobe_Polarity_Available(ic As TIS.Imaging.ICImagingControl  ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Strobe_Polarity : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return True
		Else
			Return False
		End If
	End Function


	''' <summary>
    ''' Returns, whether Strobe_Polarity is readonly.
    ''' </summary>
    ''' <param name="ic">>IC Imaging Control object</param>
    ''' <Returns>true: DevProperty is ready only, false: DevProperty is writeable</Returns>
    Public Function Strobe_Polarity_Readonly(ic As TIS.Imaging.ICImagingControl) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Strobe_Polarity : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
            Return DevProperty.ReadOnly
        Else
            Throw new System.Exception(" Strobe_Polarity Property is not supported by current device.")
		End If
		Return False
	End Function

	''' <summary>
	''' Set Strobe_Polarity value.
	''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
	''' <param name="Value">Value to set</param>
	Public Sub  Strobe_Polarity(ic As TIS.Imaging.ICImagingControl,  Value as Boolean)
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Strobe_Polarity : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			If DevProperty.ReadOnly Then
                Throw new System.Exception("Strobe_Polarity DevProperty is read only.")
			Else
				DevProperty.Switch = Value
			End If
		Else
            Throw new System.Exception("Strobe_Polarity Property is not supported by current device.")
		End If
	End Sub

    ''' <summary>
    ''' Get Strobe_Polarity value.
    ''' </summary>
	''' <param name="ic">IC Imaging Control object</param>
    ''' <Returns>Current value of Strobe_Polarity</Returns>
	Public Function Strobe_Polarity(ic As TIS.Imaging.ICImagingControl ) As Boolean
		Dim DevProperty As VCDSwitchProperty 
		If Not ic.DeviceValid Then
			Throw new System.Exception("Strobe_Polarity : No device selected")
		End If 

		DevProperty = ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580aca"), VCDGUIDs.VCDInterface_Switch)

		If Not DevProperty Is Nothing Then
			Return DevProperty.Switch
		Else
            Throw new System.Exception("Strobe_Polarity Property is not supported by current device.")
		End If
		Return False
	End Function

End Module
