using TIS.Imaging;
using System;
// C# Implemention of camera properties 
class ICProperties
{
	
	/// <summary>
    /// Check, whether Brightness is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Brightness_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Brightness : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e06-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether Brightness is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Brightness_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e06-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Brightness Property is not supported by current device.");
    }

	/// <summary>
	/// Set Brightness value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Brightness(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Brightness : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e06-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Brightness Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Brightness : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Brightness Property is not supported by current device.");
	}

    /// <summary>
    /// Get Brightness value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Brightness</returns>
	public static int Brightness(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Brightness : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e06-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Brightness Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Brightness default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of Brightness</returns>
	public static int Brightness_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Brightness : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e06-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Brightness Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Brightness minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Brightness</returns>
	public static int Brightness_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Brightness : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e06-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("Brightness Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Brightness maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Brightness</returns>
	public static int Brightness_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Brightness : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e06-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Brightness Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Contrast is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Contrast_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Contrast : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e07-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether Contrast is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Contrast_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e07-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Contrast Property is not supported by current device.");
    }

	/// <summary>
	/// Set Contrast value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Contrast(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Contrast : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e07-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Contrast Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Contrast : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Contrast Property is not supported by current device.");
	}

    /// <summary>
    /// Get Contrast value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Contrast</returns>
	public static int Contrast(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Contrast : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e07-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Contrast Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Contrast default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of Contrast</returns>
	public static int Contrast_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Contrast : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e07-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Contrast Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Contrast minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Contrast</returns>
	public static int Contrast_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Contrast : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e07-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("Contrast Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Contrast maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Contrast</returns>
	public static int Contrast_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Contrast : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e07-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Contrast Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Hue is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Hue_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Hue : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e08-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether Hue is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Hue_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e08-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Hue Property is not supported by current device.");
    }

	/// <summary>
	/// Set Hue value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Hue(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Hue : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e08-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Hue Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Hue : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Hue Property is not supported by current device.");
	}

    /// <summary>
    /// Get Hue value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Hue</returns>
	public static int Hue(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Hue : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e08-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Hue Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Hue default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of Hue</returns>
	public static int Hue_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Hue : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e08-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Hue Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Hue minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Hue</returns>
	public static int Hue_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Hue : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e08-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("Hue Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Hue maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Hue</returns>
	public static int Hue_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Hue : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e08-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Hue Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Saturation is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Saturation_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Saturation : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e09-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether Saturation is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Saturation_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e09-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Saturation Property is not supported by current device.");
    }

	/// <summary>
	/// Set Saturation value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Saturation(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Saturation : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e09-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Saturation Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Saturation : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Saturation Property is not supported by current device.");
	}

    /// <summary>
    /// Get Saturation value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Saturation</returns>
	public static int Saturation(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Saturation : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e09-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Saturation Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Saturation default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of Saturation</returns>
	public static int Saturation_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Saturation : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e09-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Saturation Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Saturation minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Saturation</returns>
	public static int Saturation_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Saturation : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e09-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("Saturation Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Saturation maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Saturation</returns>
	public static int Saturation_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Saturation : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e09-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Saturation Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Sharpness is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Sharpness_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Sharpness : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0a-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether Sharpness is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Sharpness_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0a-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Sharpness Property is not supported by current device.");
    }

	/// <summary>
	/// Set Sharpness value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Sharpness(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Sharpness : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0a-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Sharpness Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Sharpness : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Sharpness Property is not supported by current device.");
	}

    /// <summary>
    /// Get Sharpness value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Sharpness</returns>
	public static int Sharpness(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Sharpness : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0a-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Sharpness Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Sharpness default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of Sharpness</returns>
	public static int Sharpness_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Sharpness : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0a-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Sharpness Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Sharpness minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Sharpness</returns>
	public static int Sharpness_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Sharpness : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0a-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("Sharpness Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Sharpness maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Sharpness</returns>
	public static int Sharpness_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Sharpness : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0a-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Sharpness Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Gamma is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Gamma_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Gamma : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0b-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether Gamma is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Gamma_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0b-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Gamma Property is not supported by current device.");
    }

	/// <summary>
	/// Set Gamma value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Gamma(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Gamma : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0b-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Gamma Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Gamma : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Gamma Property is not supported by current device.");
	}

    /// <summary>
    /// Get Gamma value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Gamma</returns>
	public static int Gamma(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Gamma : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0b-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Gamma Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Gamma default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of Gamma</returns>
	public static int Gamma_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Gamma : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0b-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Gamma Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Gamma minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Gamma</returns>
	public static int Gamma_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Gamma : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0b-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("Gamma Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Gamma maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Gamma</returns>
	public static int Gamma_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Gamma : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0b-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Gamma Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether WhiteBalance_Auto is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool WhiteBalance_Auto_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Auto : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether WhiteBalance_Auto is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool WhiteBalance_Auto_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("WhiteBalance_Auto : No device selected");

        VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" WhiteBalance_Auto Property is not supported by current device.");
    }

	/// <summary>
	/// Set WhiteBalance_Auto value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="OnOff">Value to set</param>
	public static void WhiteBalance_Auto(TIS.Imaging.ICImagingControl ic, bool OnOff )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Auto : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("WhiteBalance_Auto Property is read only.");

                Property.Switch = OnOff;
		}
		else
            throw new System.Exception("WhiteBalance_Auto Property is not supported by current device.");
	}

    /// <summary>
    /// Get WhiteBalance_Auto value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of WhiteBalance_Auto</returns>
	public static bool WhiteBalance_Auto(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Auto : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
			return Property.Switch;
		}
		else
            throw new System.Exception("WhiteBalance_Auto Property is not supported by current device.");
	}
	
	/// <summary>
    /// Check, whether WhiteBalance_One_Push is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool WhiteBalance_One_Push_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_One_Push : No device selected");

		VCDButtonProperty Property;
		Property = (VCDButtonProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b57d3002-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Button);

		if( Property != null )
			return true;
		else
           return false;
	}


	/// <summary>
    /// Returns, whether WhiteBalance_One_Push is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool WhiteBalance_One_Push_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDButtonProperty Property;
		Property = (VCDButtonProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b57d3002-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Button);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" WhiteBalance_One_Push Property is not supported by current device.");
    }

    /// <summary>
    /// Push WhiteBalance_One_Push.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of WhiteBalance_One_Push</returns>
	public static void WhiteBalance_One_Push(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_One_Push : No device selected");

		VCDButtonProperty Property;
		Property = (VCDButtonProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b57d3002-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Button);

		if( Property != null )
		{
			Property.Push();
		}
		else
            throw new System.Exception("WhiteBalance_One_Push Property is not supported by current device.");
	}
    /// <summary>
    /// Check, whether WhiteBalance_Mode is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
    public static bool WhiteBalance_Mode_Avaialble(ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("WhiteBalance_Mode : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("ab98f78d-18a6-4eb2-a556-c11010ec9df7"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
            return true;
        else
            return false;

    }

    /// <summary>
    /// Returns, whether WhiteBalance_Mode is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool WhiteBalance_Mode_Readonly(ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("ab98f78d-18a6-4eb2-a556-c11010ec9df7"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception("WhiteBalance_Mode Property is not supported by current device.");

    }

    /// <summary>
    /// Get the current String value of WhiteBalance_Mode
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <param name="StringValue">New value.</param>

    public static System.String WhiteBalance_Mode(ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("ab98f78d-18a6-4eb2-a556-c11010ec9df7"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            return Property.String;
        }
        else
            throw new System.Exception("WhiteBalance_Mode Property is not supported by current device.");

    }

    /// <summary>
    /// Set a new String value to WhiteBalance_Mode
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>Current string</returns>
    public static void WhiteBalance_Mode(ICImagingControl ic, System.String StringValue)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("ab98f78d-18a6-4eb2-a556-c11010ec9df7"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            bool ok = false;
            string AllowedValues = "";
            for( int i = 0; i < Property.Strings.Length && !ok; i++)
            {
                AllowedValues += " \"" + Property.Strings[i] + "\"";
                ok = (StringValue == Property.Strings[i]);
            }
            if( !ok)
                throw new System.Exception(System.String.Format("WhiteBalance_Mode Property: Value \"{0}\" is not in list of {1}.", StringValue, AllowedValues));
            Property.String = StringValue;
        }
        else
            throw new System.Exception("WhiteBalance_Mode Property is not supported by current device.");

    }

    /// <summary>
    /// Returns a String array with the list of avaialble Strings of WhiteBalance_Mode
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>String []</returns>
    public static string[] WhiteBalance_Mode_GetStrings(ICImagingControl ic )
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("ab98f78d-18a6-4eb2-a556-c11010ec9df7"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            return Property.Strings;
        }
        else
            throw new System.Exception("WhiteBalance_Mode Property is not supported by current device.");

    }

    /// <summary>
    /// Check, whether WhiteBalance_Auto_Preset is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
    public static bool WhiteBalance_Auto_Preset_Avaialble(ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("WhiteBalance_Auto_Preset : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("e5f037c5-a466-4f80-a717-3e506053274a"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
            return true;
        else
            return false;

    }

    /// <summary>
    /// Returns, whether WhiteBalance_Auto_Preset is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool WhiteBalance_Auto_Preset_Readonly(ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("e5f037c5-a466-4f80-a717-3e506053274a"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception("WhiteBalance_Auto_Preset Property is not supported by current device.");

    }

    /// <summary>
    /// Get the current String value of WhiteBalance_Auto_Preset
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <param name="StringValue">New value.</param>

    public static System.String WhiteBalance_Auto_Preset(ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("e5f037c5-a466-4f80-a717-3e506053274a"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            return Property.String;
        }
        else
            throw new System.Exception("WhiteBalance_Auto_Preset Property is not supported by current device.");

    }

    /// <summary>
    /// Set a new String value to WhiteBalance_Auto_Preset
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>Current string</returns>
    public static void WhiteBalance_Auto_Preset(ICImagingControl ic, System.String StringValue)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("e5f037c5-a466-4f80-a717-3e506053274a"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            bool ok = false;
            string AllowedValues = "";
            for( int i = 0; i < Property.Strings.Length && !ok; i++)
            {
                AllowedValues += " \"" + Property.Strings[i] + "\"";
                ok = (StringValue == Property.Strings[i]);
            }
            if( !ok)
                throw new System.Exception(System.String.Format("WhiteBalance_Auto_Preset Property: Value \"{0}\" is not in list of {1}.", StringValue, AllowedValues));
            Property.String = StringValue;
        }
        else
            throw new System.Exception("WhiteBalance_Auto_Preset Property is not supported by current device.");

    }

    /// <summary>
    /// Returns a String array with the list of avaialble Strings of WhiteBalance_Auto_Preset
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>String []</returns>
    public static string[] WhiteBalance_Auto_Preset_GetStrings(ICImagingControl ic )
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("e5f037c5-a466-4f80-a717-3e506053274a"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            return Property.Strings;
        }
        else
            throw new System.Exception("WhiteBalance_Auto_Preset Property is not supported by current device.");

    }

    /// <summary>
    /// Check, whether WhiteBalance_Temperature_Preset is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
    public static bool WhiteBalance_Temperature_Preset_Avaialble(ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("WhiteBalance_Temperature_Preset : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("88143b6d-a1c5-45d6-bf7f-95f6447ab1be"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
            return true;
        else
            return false;

    }

    /// <summary>
    /// Returns, whether WhiteBalance_Temperature_Preset is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool WhiteBalance_Temperature_Preset_Readonly(ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("88143b6d-a1c5-45d6-bf7f-95f6447ab1be"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception("WhiteBalance_Temperature_Preset Property is not supported by current device.");

    }

    /// <summary>
    /// Get the current String value of WhiteBalance_Temperature_Preset
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <param name="StringValue">New value.</param>

    public static System.String WhiteBalance_Temperature_Preset(ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("88143b6d-a1c5-45d6-bf7f-95f6447ab1be"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            return Property.String;
        }
        else
            throw new System.Exception("WhiteBalance_Temperature_Preset Property is not supported by current device.");

    }

    /// <summary>
    /// Set a new String value to WhiteBalance_Temperature_Preset
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>Current string</returns>
    public static void WhiteBalance_Temperature_Preset(ICImagingControl ic, System.String StringValue)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("88143b6d-a1c5-45d6-bf7f-95f6447ab1be"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            bool ok = false;
            string AllowedValues = "";
            for( int i = 0; i < Property.Strings.Length && !ok; i++)
            {
                AllowedValues += " \"" + Property.Strings[i] + "\"";
                ok = (StringValue == Property.Strings[i]);
            }
            if( !ok)
                throw new System.Exception(System.String.Format("WhiteBalance_Temperature_Preset Property: Value \"{0}\" is not in list of {1}.", StringValue, AllowedValues));
            Property.String = StringValue;
        }
        else
            throw new System.Exception("WhiteBalance_Temperature_Preset Property is not supported by current device.");

    }

    /// <summary>
    /// Returns a String array with the list of avaialble Strings of WhiteBalance_Temperature_Preset
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>String []</returns>
    public static string[] WhiteBalance_Temperature_Preset_GetStrings(ICImagingControl ic )
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("88143b6d-a1c5-45d6-bf7f-95f6447ab1be"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            return Property.Strings;
        }
        else
            throw new System.Exception("WhiteBalance_Temperature_Preset Property is not supported by current device.");

    }

	
	/// <summary>
    /// Check, whether WhiteBalance_Temperature is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool WhiteBalance_Temperature_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Temperature : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b8d65671-94e0-4dbb-9275-0c29d4f6ba87"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether WhiteBalance_Temperature is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool WhiteBalance_Temperature_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b8d65671-94e0-4dbb-9275-0c29d4f6ba87"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" WhiteBalance_Temperature Property is not supported by current device.");
    }

	/// <summary>
	/// Set WhiteBalance_Temperature value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void WhiteBalance_Temperature(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Temperature : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b8d65671-94e0-4dbb-9275-0c29d4f6ba87"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("WhiteBalance_Temperature Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "WhiteBalance_Temperature : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("WhiteBalance_Temperature Property is not supported by current device.");
	}

    /// <summary>
    /// Get WhiteBalance_Temperature value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of WhiteBalance_Temperature</returns>
	public static int WhiteBalance_Temperature(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Temperature : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b8d65671-94e0-4dbb-9275-0c29d4f6ba87"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("WhiteBalance_Temperature Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Temperature default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of WhiteBalance_Temperature</returns>
	public static int WhiteBalance_Temperature_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Temperature : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b8d65671-94e0-4dbb-9275-0c29d4f6ba87"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("WhiteBalance_Temperature Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Temperature minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of WhiteBalance_Temperature</returns>
	public static int WhiteBalance_Temperature_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Temperature : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b8d65671-94e0-4dbb-9275-0c29d4f6ba87"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("WhiteBalance_Temperature Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Temperature maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of WhiteBalance_Temperature</returns>
	public static int WhiteBalance_Temperature_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Temperature : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("b8d65671-94e0-4dbb-9275-0c29d4f6ba87"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("WhiteBalance_Temperature Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether WhiteBalance_Red is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool WhiteBalance_Red_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Red : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038b-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether WhiteBalance_Red is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool WhiteBalance_Red_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038b-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" WhiteBalance_Red Property is not supported by current device.");
    }

	/// <summary>
	/// Set WhiteBalance_Red value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void WhiteBalance_Red(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Red : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038b-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("WhiteBalance_Red Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "WhiteBalance_Red : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("WhiteBalance_Red Property is not supported by current device.");
	}

    /// <summary>
    /// Get WhiteBalance_Red value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of WhiteBalance_Red</returns>
	public static int WhiteBalance_Red(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Red : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038b-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("WhiteBalance_Red Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Red default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of WhiteBalance_Red</returns>
	public static int WhiteBalance_Red_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Red : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038b-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("WhiteBalance_Red Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Red minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of WhiteBalance_Red</returns>
	public static int WhiteBalance_Red_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Red : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038b-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("WhiteBalance_Red Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Red maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of WhiteBalance_Red</returns>
	public static int WhiteBalance_Red_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Red : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038b-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("WhiteBalance_Red Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether WhiteBalance_Green is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool WhiteBalance_Green_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Green : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("8407e480-175a-498c-8171-08bd987cc1ac"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether WhiteBalance_Green is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool WhiteBalance_Green_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("8407e480-175a-498c-8171-08bd987cc1ac"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" WhiteBalance_Green Property is not supported by current device.");
    }

	/// <summary>
	/// Set WhiteBalance_Green value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void WhiteBalance_Green(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Green : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("8407e480-175a-498c-8171-08bd987cc1ac"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("WhiteBalance_Green Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "WhiteBalance_Green : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("WhiteBalance_Green Property is not supported by current device.");
	}

    /// <summary>
    /// Get WhiteBalance_Green value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of WhiteBalance_Green</returns>
	public static int WhiteBalance_Green(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Green : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("8407e480-175a-498c-8171-08bd987cc1ac"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("WhiteBalance_Green Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Green default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of WhiteBalance_Green</returns>
	public static int WhiteBalance_Green_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Green : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("8407e480-175a-498c-8171-08bd987cc1ac"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("WhiteBalance_Green Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Green minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of WhiteBalance_Green</returns>
	public static int WhiteBalance_Green_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Green : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("8407e480-175a-498c-8171-08bd987cc1ac"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("WhiteBalance_Green Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Green maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of WhiteBalance_Green</returns>
	public static int WhiteBalance_Green_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Green : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("8407e480-175a-498c-8171-08bd987cc1ac"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("WhiteBalance_Green Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether WhiteBalance_Blue is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool WhiteBalance_Blue_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Blue : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038a-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether WhiteBalance_Blue is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool WhiteBalance_Blue_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038a-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" WhiteBalance_Blue Property is not supported by current device.");
    }

	/// <summary>
	/// Set WhiteBalance_Blue value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void WhiteBalance_Blue(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Blue : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038a-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("WhiteBalance_Blue Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "WhiteBalance_Blue : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("WhiteBalance_Blue Property is not supported by current device.");
	}

    /// <summary>
    /// Get WhiteBalance_Blue value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of WhiteBalance_Blue</returns>
	public static int WhiteBalance_Blue(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Blue : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038a-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("WhiteBalance_Blue Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Blue default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of WhiteBalance_Blue</returns>
	public static int WhiteBalance_Blue_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Blue : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038a-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("WhiteBalance_Blue Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Blue minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of WhiteBalance_Blue</returns>
	public static int WhiteBalance_Blue_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Blue : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038a-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("WhiteBalance_Blue Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Blue maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of WhiteBalance_Blue</returns>
	public static int WhiteBalance_Blue_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("WhiteBalance_Blue : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0d-010b-45bf-8291-09d90a459b28"), new Guid("6519038a-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("WhiteBalance_Blue Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Gain is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Gain_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Gain : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether Gain is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Gain_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Gain Property is not supported by current device.");
    }

	/// <summary>
	/// Set Gain value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Gain(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Gain : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Gain Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Gain : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Gain Property is not supported by current device.");
	}

    /// <summary>
    /// Get Gain value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Gain</returns>
	public static int Gain(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Gain : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Gain Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Gain default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of Gain</returns>
	public static int Gain_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Gain : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Gain Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Gain minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Gain</returns>
	public static int Gain_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Gain : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("Gain Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Gain maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Gain</returns>
	public static int Gain_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Gain : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Gain Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Gain_Auto is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Gain_Auto_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Gain_Auto : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Gain_Auto is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Gain_Auto_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Gain_Auto : No device selected");

        VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Gain_Auto Property is not supported by current device.");
    }

	/// <summary>
	/// Set Gain_Auto value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="OnOff">Value to set</param>
	public static void Gain_Auto(TIS.Imaging.ICImagingControl ic, bool OnOff )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Gain_Auto : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Gain_Auto Property is read only.");

                Property.Switch = OnOff;
		}
		else
            throw new System.Exception("Gain_Auto Property is not supported by current device.");
	}

    /// <summary>
    /// Get Gain_Auto value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Gain_Auto</returns>
	public static bool Gain_Auto(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Gain_Auto : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("284c0e0f-010b-45bf-8291-09d90a459b28"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
			return Property.Switch;
		}
		else
            throw new System.Exception("Gain_Auto Property is not supported by current device.");
	}
	
	/// <summary>
    /// Check, whether Exposure is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Exposure_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether Exposure is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Exposure_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Exposure Property is not supported by current device.");
    }

	/// <summary>
	/// Set Exposure value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Exposure(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Exposure Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Exposure : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Exposure Property is not supported by current device.");
	}

    /// <summary>
    /// Get Exposure value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Exposure</returns>
	public static int Exposure(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Exposure Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of Exposure</returns>
	public static int Exposure_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Exposure Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure</returns>
	public static int Exposure_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("Exposure Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Exposure</returns>
	public static int Exposure_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Exposure Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Exposure is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Exposure_Abs_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Exposure is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Exposure_Abs_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_AbsoluteValue);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Exposure Property is not supported by current device.");
    }

	/// <summary>
	/// Set Exposure value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Exposure_Abs(TIS.Imaging.ICImagingControl ic, double Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Exposure Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Exposure : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Exposure Property is not supported by current device.");
	}

    /// <summary>
    /// Get Exposure value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Exposure</returns>
	public static double Exposure_Abs(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Exposure Property is not supported by current device.");
		
	}
	/// <summary>
    /// Get Exposure default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure</returns>
	public static double Exposure_Abs_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Exposure Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure</returns>
	public static double Exposure_Abs_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Exposure Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Exposure</returns>
	public static double Exposure_Abs_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Exposure Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Exposure_Auto is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Exposure_Auto_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Exposure_Auto is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Exposure_Auto_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Exposure_Auto : No device selected");

        VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Exposure_Auto Property is not supported by current device.");
    }

	/// <summary>
	/// Set Exposure_Auto value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="OnOff">Value to set</param>
	public static void Exposure_Auto(TIS.Imaging.ICImagingControl ic, bool OnOff )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Exposure_Auto Property is read only.");

                Property.Switch = OnOff;
		}
		else
            throw new System.Exception("Exposure_Auto Property is not supported by current device.");
	}

    /// <summary>
    /// Get Exposure_Auto value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Exposure_Auto</returns>
	public static bool Exposure_Auto(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
			return Property.Switch;
		}
		else
            throw new System.Exception("Exposure_Auto Property is not supported by current device.");
	}
	
	/// <summary>
    /// Check, whether Exposure_Auto_Reference is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Exposure_Auto_Reference_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Reference : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038c-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether Exposure_Auto_Reference is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Exposure_Auto_Reference_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038c-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Exposure_Auto_Reference Property is not supported by current device.");
    }

	/// <summary>
	/// Set Exposure_Auto_Reference value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Exposure_Auto_Reference(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Reference : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038c-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Exposure_Auto_Reference Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Exposure_Auto_Reference : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Exposure_Auto_Reference Property is not supported by current device.");
	}

    /// <summary>
    /// Get Exposure_Auto_Reference value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Exposure_Auto_Reference</returns>
	public static int Exposure_Auto_Reference(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Reference : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038c-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Exposure_Auto_Reference Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure_Auto_Reference default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of Exposure_Auto_Reference</returns>
	public static int Exposure_Auto_Reference_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Reference : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038c-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Exposure_Auto_Reference Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure_Auto_Reference minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure_Auto_Reference</returns>
	public static int Exposure_Auto_Reference_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Reference : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038c-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("Exposure_Auto_Reference Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure_Auto_Reference maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Exposure_Auto_Reference</returns>
	public static int Exposure_Auto_Reference_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Reference : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038c-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Exposure_Auto_Reference Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Exposure_Auto_Max_Value is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Exposure_Auto_Max_Value_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Max_Value : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether Exposure_Auto_Max_Value is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Exposure_Auto_Max_Value_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Exposure_Auto_Max_Value Property is not supported by current device.");
    }

	/// <summary>
	/// Set Exposure_Auto_Max_Value value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Exposure_Auto_Max_Value(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Max_Value : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Exposure_Auto_Max_Value Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Exposure_Auto_Max_Value : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.");
	}

    /// <summary>
    /// Get Exposure_Auto_Max_Value value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Exposure_Auto_Max_Value</returns>
	public static int Exposure_Auto_Max_Value(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Max_Value : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure_Auto_Max_Value default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of Exposure_Auto_Max_Value</returns>
	public static int Exposure_Auto_Max_Value_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Max_Value : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure_Auto_Max_Value minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure_Auto_Max_Value</returns>
	public static int Exposure_Auto_Max_Value_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Max_Value : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure_Auto_Max_Value maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Exposure_Auto_Max_Value</returns>
	public static int Exposure_Auto_Max_Value_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Max_Value : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Exposure_Auto_Max_Value is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Exposure_Auto_Max_Value_Abs_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Max_Value : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Exposure_Auto_Max_Value is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Exposure_Auto_Max_Value_Abs_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_AbsoluteValue);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Exposure_Auto_Max_Value Property is not supported by current device.");
    }

	/// <summary>
	/// Set Exposure_Auto_Max_Value value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Exposure_Auto_Max_Value_Abs(TIS.Imaging.ICImagingControl ic, double Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Max_Value : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Exposure_Auto_Max_Value Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Exposure_Auto_Max_Value : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.");
	}

    /// <summary>
    /// Get Exposure_Auto_Max_Value value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Exposure_Auto_Max_Value</returns>
	public static double Exposure_Auto_Max_Value_Abs(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Max_Value : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.");
		
	}
	/// <summary>
    /// Get Exposure_Auto_Max_Value default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure_Auto_Max_Value</returns>
	public static double Exposure_Auto_Max_Value_Abs_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Max_Value : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure_Auto_Max_Value minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure_Auto_Max_Value</returns>
	public static double Exposure_Auto_Max_Value_Abs_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Max_Value : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure_Auto_Max_Value maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Exposure_Auto_Max_Value</returns>
	public static double Exposure_Auto_Max_Value_Abs_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_Auto_Max_Value : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("6519038f-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Exposure_Auto_Max_Value Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Exposure_MaxAutoAuto is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Exposure_MaxAutoAuto_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_MaxAutoAuto : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("65190390-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Exposure_MaxAutoAuto is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Exposure_MaxAutoAuto_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Exposure_MaxAutoAuto : No device selected");

        VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("65190390-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Switch);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Exposure_MaxAutoAuto Property is not supported by current device.");
    }

	/// <summary>
	/// Set Exposure_MaxAutoAuto value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="OnOff">Value to set</param>
	public static void Exposure_MaxAutoAuto(TIS.Imaging.ICImagingControl ic, bool OnOff )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_MaxAutoAuto : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("65190390-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Exposure_MaxAutoAuto Property is read only.");

                Property.Switch = OnOff;
		}
		else
            throw new System.Exception("Exposure_MaxAutoAuto Property is not supported by current device.");
	}

    /// <summary>
    /// Get Exposure_MaxAutoAuto value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Exposure_MaxAutoAuto</returns>
	public static bool Exposure_MaxAutoAuto(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Exposure_MaxAutoAuto : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d5702e-e43b-4366-aaeb-7a7a10b448b4"), new Guid("65190390-1ad8-4e91-9021-66d64090cc85"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
			return Property.Switch;
		}
		else
            throw new System.Exception("Exposure_MaxAutoAuto Property is not supported by current device.");
	}
	
	/// <summary>
    /// Check, whether Trigger_Enable is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Trigger_Enable_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Trigger_Enable : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d57031-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Trigger_Enable is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Trigger_Enable_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Trigger_Enable : No device selected");

        VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d57031-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Trigger_Enable Property is not supported by current device.");
    }

	/// <summary>
	/// Set Trigger_Enable value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="OnOff">Value to set</param>
	public static void Trigger_Enable(TIS.Imaging.ICImagingControl ic, bool OnOff )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Trigger_Enable : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d57031-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Trigger_Enable Property is read only.");

                Property.Switch = OnOff;
		}
		else
            throw new System.Exception("Trigger_Enable Property is not supported by current device.");
	}

    /// <summary>
    /// Get Trigger_Enable value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Trigger_Enable</returns>
	public static bool Trigger_Enable(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Trigger_Enable : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d57031-e43b-4366-aaeb-7a7a10b448b4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
			return Property.Switch;
		}
		else
            throw new System.Exception("Trigger_Enable Property is not supported by current device.");
	}
	
	/// <summary>
    /// Check, whether Trigger_Software is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Trigger_Software_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Trigger_Software : No device selected");

		VCDButtonProperty Property;
		Property = (VCDButtonProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d57031-e43b-4366-aaeb-7a7a10b448b4"), new Guid("fdb4003c-552c-4faa-b87b-42e888d54147"), VCDGUIDs.VCDInterface_Button);

		if( Property != null )
			return true;
		else
           return false;
	}


	/// <summary>
    /// Returns, whether Trigger_Software is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Trigger_Software_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDButtonProperty Property;
		Property = (VCDButtonProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d57031-e43b-4366-aaeb-7a7a10b448b4"), new Guid("fdb4003c-552c-4faa-b87b-42e888d54147"), VCDGUIDs.VCDInterface_Button);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Trigger_Software Property is not supported by current device.");
    }

    /// <summary>
    /// Push Trigger_Software.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Trigger_Software</returns>
	public static void Trigger_Software(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Trigger_Software : No device selected");

		VCDButtonProperty Property;
		Property = (VCDButtonProperty)ic.VCDPropertyItems.FindInterface(new Guid("90d57031-e43b-4366-aaeb-7a7a10b448b4"), new Guid("fdb4003c-552c-4faa-b87b-42e888d54147"), VCDGUIDs.VCDInterface_Button);

		if( Property != null )
		{
			Property.Push();
		}
		else
            throw new System.Exception("Trigger_Software Property is not supported by current device.");
	}
	
	/// <summary>
    /// Check, whether Denoise is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Denoise_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Denoise : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("c3c9944a-e6f6-4e25-a0be-53c066ab65d8"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether Denoise is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Denoise_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("c3c9944a-e6f6-4e25-a0be-53c066ab65d8"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Denoise Property is not supported by current device.");
    }

	/// <summary>
	/// Set Denoise value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Denoise(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Denoise : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("c3c9944a-e6f6-4e25-a0be-53c066ab65d8"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Denoise Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Denoise : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Denoise Property is not supported by current device.");
	}

    /// <summary>
    /// Get Denoise value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Denoise</returns>
	public static int Denoise(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Denoise : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("c3c9944a-e6f6-4e25-a0be-53c066ab65d8"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Denoise Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Denoise default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of Denoise</returns>
	public static int Denoise_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Denoise : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("c3c9944a-e6f6-4e25-a0be-53c066ab65d8"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Denoise Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Denoise minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Denoise</returns>
	public static int Denoise_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Denoise : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("c3c9944a-e6f6-4e25-a0be-53c066ab65d8"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("Denoise Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Denoise maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Denoise</returns>
	public static int Denoise_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Denoise : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("c3c9944a-e6f6-4e25-a0be-53c066ab65d8"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Denoise Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether GPIO_GP_IN is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool GPIO_GP_IN_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("GPIO_GP_IN : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a500"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether GPIO_GP_IN is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool GPIO_GP_IN_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a500"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" GPIO_GP_IN Property is not supported by current device.");
    }

	/// <summary>
	/// Set GPIO_GP_IN value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void GPIO_GP_IN(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("GPIO_GP_IN : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a500"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("GPIO_GP_IN Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "GPIO_GP_IN : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("GPIO_GP_IN Property is not supported by current device.");
	}

    /// <summary>
    /// Get GPIO_GP_IN value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of GPIO_GP_IN</returns>
	public static int GPIO_GP_IN(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("GPIO_GP_IN : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a500"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("GPIO_GP_IN Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get GPIO_GP_IN default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of GPIO_GP_IN</returns>
	public static int GPIO_GP_IN_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("GPIO_GP_IN : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a500"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("GPIO_GP_IN Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get GPIO_GP_IN minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of GPIO_GP_IN</returns>
	public static int GPIO_GP_IN_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("GPIO_GP_IN : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a500"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("GPIO_GP_IN Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get GPIO_GP_IN maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of GPIO_GP_IN</returns>
	public static int GPIO_GP_IN_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("GPIO_GP_IN : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a500"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("GPIO_GP_IN Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether GPIO_Read is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool GPIO_Read_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("GPIO_Read : No device selected");

		VCDButtonProperty Property;
		Property = (VCDButtonProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a503"), VCDGUIDs.VCDInterface_Button);

		if( Property != null )
			return true;
		else
           return false;
	}


	/// <summary>
    /// Returns, whether GPIO_Read is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool GPIO_Read_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDButtonProperty Property;
		Property = (VCDButtonProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a503"), VCDGUIDs.VCDInterface_Button);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" GPIO_Read Property is not supported by current device.");
    }

    /// <summary>
    /// Push GPIO_Read.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of GPIO_Read</returns>
	public static void GPIO_Read(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("GPIO_Read : No device selected");

		VCDButtonProperty Property;
		Property = (VCDButtonProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a503"), VCDGUIDs.VCDInterface_Button);

		if( Property != null )
		{
			Property.Push();
		}
		else
            throw new System.Exception("GPIO_Read Property is not supported by current device.");
	}
	
	/// <summary>
    /// Check, whether GPIO_GP_Out is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool GPIO_GP_Out_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("GPIO_GP_Out : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a501"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether GPIO_GP_Out is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool GPIO_GP_Out_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a501"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" GPIO_GP_Out Property is not supported by current device.");
    }

	/// <summary>
	/// Set GPIO_GP_Out value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void GPIO_GP_Out(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("GPIO_GP_Out : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a501"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("GPIO_GP_Out Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "GPIO_GP_Out : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("GPIO_GP_Out Property is not supported by current device.");
	}

    /// <summary>
    /// Get GPIO_GP_Out value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of GPIO_GP_Out</returns>
	public static int GPIO_GP_Out(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("GPIO_GP_Out : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a501"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("GPIO_GP_Out Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get GPIO_GP_Out default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of GPIO_GP_Out</returns>
	public static int GPIO_GP_Out_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("GPIO_GP_Out : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a501"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("GPIO_GP_Out Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get GPIO_GP_Out minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of GPIO_GP_Out</returns>
	public static int GPIO_GP_Out_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("GPIO_GP_Out : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a501"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("GPIO_GP_Out Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get GPIO_GP_Out maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of GPIO_GP_Out</returns>
	public static int GPIO_GP_Out_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("GPIO_GP_Out : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a501"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("GPIO_GP_Out Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether GPIO_Write is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool GPIO_Write_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("GPIO_Write : No device selected");

		VCDButtonProperty Property;
		Property = (VCDButtonProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a502"), VCDGUIDs.VCDInterface_Button);

		if( Property != null )
			return true;
		else
           return false;
	}


	/// <summary>
    /// Returns, whether GPIO_Write is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool GPIO_Write_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDButtonProperty Property;
		Property = (VCDButtonProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a502"), VCDGUIDs.VCDInterface_Button);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" GPIO_Write Property is not supported by current device.");
    }

    /// <summary>
    /// Push GPIO_Write.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of GPIO_Write</returns>
	public static void GPIO_Write(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("GPIO_Write : No device selected");

		VCDButtonProperty Property;
		Property = (VCDButtonProperty)ic.VCDPropertyItems.FindInterface(new Guid("86d89d69-9880-4618-9bf6-ded5e8383449"), new Guid("7d006621-761d-4b88-9c5f-8b906857a502"), VCDGUIDs.VCDInterface_Button);

		if( Property != null )
		{
			Property.Push();
		}
		else
            throw new System.Exception("GPIO_Write Property is not supported by current device.");
	}
    /// <summary>
    /// Check, whether Binning_factor is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
    public static bool Binning_factor_Avaialble(ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Binning_factor : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("4f95a06d-9c15-407b-96ab-cf3fed047ba4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
            return true;
        else
            return false;

    }

    /// <summary>
    /// Returns, whether Binning_factor is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Binning_factor_Readonly(ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("4f95a06d-9c15-407b-96ab-cf3fed047ba4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception("Binning_factor Property is not supported by current device.");

    }

    /// <summary>
    /// Get the current String value of Binning_factor
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <param name="StringValue">New value.</param>

    public static System.String Binning_factor(ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("4f95a06d-9c15-407b-96ab-cf3fed047ba4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            return Property.String;
        }
        else
            throw new System.Exception("Binning_factor Property is not supported by current device.");

    }

    /// <summary>
    /// Set a new String value to Binning_factor
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>Current string</returns>
    public static void Binning_factor(ICImagingControl ic, System.String StringValue)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("4f95a06d-9c15-407b-96ab-cf3fed047ba4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            bool ok = false;
            string AllowedValues = "";
            for( int i = 0; i < Property.Strings.Length && !ok; i++)
            {
                AllowedValues += " \"" + Property.Strings[i] + "\"";
                ok = (StringValue == Property.Strings[i]);
            }
            if( !ok)
                throw new System.Exception(System.String.Format("Binning_factor Property: Value \"{0}\" is not in list of {1}.", StringValue, AllowedValues));
            Property.String = StringValue;
        }
        else
            throw new System.Exception("Binning_factor Property is not supported by current device.");

    }

    /// <summary>
    /// Returns a String array with the list of avaialble Strings of Binning_factor
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>String []</returns>
    public static string[] Binning_factor_GetStrings(ICImagingControl ic )
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("4f95a06d-9c15-407b-96ab-cf3fed047ba4"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            return Property.Strings;
        }
        else
            throw new System.Exception("Binning_factor Property is not supported by current device.");

    }

	
	/// <summary>
    /// Check, whether Color_Enhancement_Enable is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Color_Enhancement_Enable_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Color_Enhancement_Enable : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("3a3a8f77-6440-46cc-940a-8752b02e6c29"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Color_Enhancement_Enable is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Color_Enhancement_Enable_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Color_Enhancement_Enable : No device selected");

        VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("3a3a8f77-6440-46cc-940a-8752b02e6c29"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Color_Enhancement_Enable Property is not supported by current device.");
    }

	/// <summary>
	/// Set Color_Enhancement_Enable value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="OnOff">Value to set</param>
	public static void Color_Enhancement_Enable(TIS.Imaging.ICImagingControl ic, bool OnOff )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Color_Enhancement_Enable : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("3a3a8f77-6440-46cc-940a-8752b02e6c29"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Color_Enhancement_Enable Property is read only.");

                Property.Switch = OnOff;
		}
		else
            throw new System.Exception("Color_Enhancement_Enable Property is not supported by current device.");
	}

    /// <summary>
    /// Get Color_Enhancement_Enable value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Color_Enhancement_Enable</returns>
	public static bool Color_Enhancement_Enable(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Color_Enhancement_Enable : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("3a3a8f77-6440-46cc-940a-8752b02e6c29"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
			return Property.Switch;
		}
		else
            throw new System.Exception("Color_Enhancement_Enable Property is not supported by current device.");
	}
	
	/// <summary>
    /// Check, whether Highlight_reduction_Enable is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Highlight_reduction_Enable_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Highlight_reduction_Enable : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("546541ad-c815-4d82-afa9-9d59af9f399e"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Highlight_reduction_Enable is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Highlight_reduction_Enable_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Highlight_reduction_Enable : No device selected");

        VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("546541ad-c815-4d82-afa9-9d59af9f399e"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Highlight_reduction_Enable Property is not supported by current device.");
    }

	/// <summary>
	/// Set Highlight_reduction_Enable value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="OnOff">Value to set</param>
	public static void Highlight_reduction_Enable(TIS.Imaging.ICImagingControl ic, bool OnOff )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Highlight_reduction_Enable : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("546541ad-c815-4d82-afa9-9d59af9f399e"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Highlight_reduction_Enable Property is read only.");

                Property.Switch = OnOff;
		}
		else
            throw new System.Exception("Highlight_reduction_Enable Property is not supported by current device.");
	}

    /// <summary>
    /// Get Highlight_reduction_Enable value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Highlight_reduction_Enable</returns>
	public static bool Highlight_reduction_Enable(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Highlight_reduction_Enable : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("546541ad-c815-4d82-afa9-9d59af9f399e"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
			return Property.Switch;
		}
		else
            throw new System.Exception("Highlight_reduction_Enable Property is not supported by current device.");
	}
	
	/// <summary>
    /// Check, whether Tone_Mapping_Enable is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Tone_Mapping_Enable_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Enable : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Tone_Mapping_Enable is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Tone_Mapping_Enable_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Tone_Mapping_Enable : No device selected");

        VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Tone_Mapping_Enable Property is not supported by current device.");
    }

	/// <summary>
	/// Set Tone_Mapping_Enable value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="OnOff">Value to set</param>
	public static void Tone_Mapping_Enable(TIS.Imaging.ICImagingControl ic, bool OnOff )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Enable : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Tone_Mapping_Enable Property is read only.");

                Property.Switch = OnOff;
		}
		else
            throw new System.Exception("Tone_Mapping_Enable Property is not supported by current device.");
	}

    /// <summary>
    /// Get Tone_Mapping_Enable value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Tone_Mapping_Enable</returns>
	public static bool Tone_Mapping_Enable(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Enable : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
			return Property.Switch;
		}
		else
            throw new System.Exception("Tone_Mapping_Enable Property is not supported by current device.");
	}
	
	/// <summary>
    /// Check, whether Tone_Mapping_Auto is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Tone_Mapping_Auto_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Auto : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Tone_Mapping_Auto is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Tone_Mapping_Auto_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Tone_Mapping_Auto : No device selected");

        VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Tone_Mapping_Auto Property is not supported by current device.");
    }

	/// <summary>
	/// Set Tone_Mapping_Auto value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="OnOff">Value to set</param>
	public static void Tone_Mapping_Auto(TIS.Imaging.ICImagingControl ic, bool OnOff )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Auto : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Tone_Mapping_Auto Property is read only.");

                Property.Switch = OnOff;
		}
		else
            throw new System.Exception("Tone_Mapping_Auto Property is not supported by current device.");
	}

    /// <summary>
    /// Get Tone_Mapping_Auto value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Tone_Mapping_Auto</returns>
	public static bool Tone_Mapping_Auto(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Auto : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("b57d3001-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
			return Property.Switch;
		}
		else
            throw new System.Exception("Tone_Mapping_Auto Property is not supported by current device.");
	}
	
	/// <summary>
    /// Check, whether Tone_Mapping_Intensity is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Tone_Mapping_Intensity_Abs_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Intensity : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("bd2f432a-02c1-4f32-9aeb-687ca117d2e7"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Tone_Mapping_Intensity is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Tone_Mapping_Intensity_Abs_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("bd2f432a-02c1-4f32-9aeb-687ca117d2e7"), VCDGUIDs.VCDInterface_AbsoluteValue);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Tone_Mapping_Intensity Property is not supported by current device.");
    }

	/// <summary>
	/// Set Tone_Mapping_Intensity value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Tone_Mapping_Intensity_Abs(TIS.Imaging.ICImagingControl ic, double Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Intensity : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("bd2f432a-02c1-4f32-9aeb-687ca117d2e7"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Tone_Mapping_Intensity Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Tone_Mapping_Intensity : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Tone_Mapping_Intensity Property is not supported by current device.");
	}

    /// <summary>
    /// Get Tone_Mapping_Intensity value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Tone_Mapping_Intensity</returns>
	public static double Tone_Mapping_Intensity_Abs(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Intensity : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("bd2f432a-02c1-4f32-9aeb-687ca117d2e7"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Tone_Mapping_Intensity Property is not supported by current device.");
		
	}
	/// <summary>
    /// Get Tone_Mapping_Intensity default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_Intensity</returns>
	public static double Tone_Mapping_Intensity_Abs_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Intensity : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("bd2f432a-02c1-4f32-9aeb-687ca117d2e7"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Tone_Mapping_Intensity Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_Intensity minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_Intensity</returns>
	public static double Tone_Mapping_Intensity_Abs_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Intensity : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("bd2f432a-02c1-4f32-9aeb-687ca117d2e7"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Tone_Mapping_Intensity Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_Intensity maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Tone_Mapping_Intensity</returns>
	public static double Tone_Mapping_Intensity_Abs_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Intensity : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("bd2f432a-02c1-4f32-9aeb-687ca117d2e7"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Tone_Mapping_Intensity Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Tone_Mapping_Global_Brightness_Factor is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Tone_Mapping_Global_Brightness_Factor_Abs_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Global_Brightness_Factor : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("d1451fed-c2d8-42ce-910b-2cb566836a77"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Tone_Mapping_Global_Brightness_Factor is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Tone_Mapping_Global_Brightness_Factor_Abs_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("d1451fed-c2d8-42ce-910b-2cb566836a77"), VCDGUIDs.VCDInterface_AbsoluteValue);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.");
    }

	/// <summary>
	/// Set Tone_Mapping_Global_Brightness_Factor value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Tone_Mapping_Global_Brightness_Factor_Abs(TIS.Imaging.ICImagingControl ic, double Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Global_Brightness_Factor : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("d1451fed-c2d8-42ce-910b-2cb566836a77"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Tone_Mapping_Global_Brightness_Factor Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Tone_Mapping_Global_Brightness_Factor : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.");
	}

    /// <summary>
    /// Get Tone_Mapping_Global_Brightness_Factor value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Tone_Mapping_Global_Brightness_Factor</returns>
	public static double Tone_Mapping_Global_Brightness_Factor_Abs(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Global_Brightness_Factor : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("d1451fed-c2d8-42ce-910b-2cb566836a77"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.");
		
	}
	/// <summary>
    /// Get Tone_Mapping_Global_Brightness_Factor default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_Global_Brightness_Factor</returns>
	public static double Tone_Mapping_Global_Brightness_Factor_Abs_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Global_Brightness_Factor : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("d1451fed-c2d8-42ce-910b-2cb566836a77"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_Global_Brightness_Factor minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_Global_Brightness_Factor</returns>
	public static double Tone_Mapping_Global_Brightness_Factor_Abs_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Global_Brightness_Factor : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("d1451fed-c2d8-42ce-910b-2cb566836a77"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_Global_Brightness_Factor maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Tone_Mapping_Global_Brightness_Factor</returns>
	public static double Tone_Mapping_Global_Brightness_Factor_Abs_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_Global_Brightness_Factor : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("d1451fed-c2d8-42ce-910b-2cb566836a77"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Tone_Mapping_a is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Tone_Mapping_a_Abs_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_a : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Tone_Mapping_a is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Tone_Mapping_a_Abs_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179"), VCDGUIDs.VCDInterface_AbsoluteValue);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Tone_Mapping_a Property is not supported by current device.");
    }

	/// <summary>
	/// Set Tone_Mapping_a value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Tone_Mapping_a_Abs(TIS.Imaging.ICImagingControl ic, double Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_a : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Tone_Mapping_a Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Tone_Mapping_a : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Tone_Mapping_a Property is not supported by current device.");
	}

    /// <summary>
    /// Get Tone_Mapping_a value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Tone_Mapping_a</returns>
	public static double Tone_Mapping_a_Abs(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_a : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Tone_Mapping_a Property is not supported by current device.");
		
	}
	/// <summary>
    /// Get Tone_Mapping_a default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_a</returns>
	public static double Tone_Mapping_a_Abs_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_a : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Tone_Mapping_a Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_a minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_a</returns>
	public static double Tone_Mapping_a_Abs_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_a : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Tone_Mapping_a Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_a maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Tone_Mapping_a</returns>
	public static double Tone_Mapping_a_Abs_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_a : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Tone_Mapping_a Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Tone_Mapping_b is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Tone_Mapping_b_Abs_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_b : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("8a1a5755-a562-470b-9842-97b08791144c"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Tone_Mapping_b is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Tone_Mapping_b_Abs_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("8a1a5755-a562-470b-9842-97b08791144c"), VCDGUIDs.VCDInterface_AbsoluteValue);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Tone_Mapping_b Property is not supported by current device.");
    }

	/// <summary>
	/// Set Tone_Mapping_b value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Tone_Mapping_b_Abs(TIS.Imaging.ICImagingControl ic, double Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_b : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("8a1a5755-a562-470b-9842-97b08791144c"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Tone_Mapping_b Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Tone_Mapping_b : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Tone_Mapping_b Property is not supported by current device.");
	}

    /// <summary>
    /// Get Tone_Mapping_b value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Tone_Mapping_b</returns>
	public static double Tone_Mapping_b_Abs(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_b : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("8a1a5755-a562-470b-9842-97b08791144c"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Tone_Mapping_b Property is not supported by current device.");
		
	}
	/// <summary>
    /// Get Tone_Mapping_b default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_b</returns>
	public static double Tone_Mapping_b_Abs_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_b : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("8a1a5755-a562-470b-9842-97b08791144c"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Tone_Mapping_b Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_b minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_b</returns>
	public static double Tone_Mapping_b_Abs_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_b : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("8a1a5755-a562-470b-9842-97b08791144c"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Tone_Mapping_b Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_b maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Tone_Mapping_b</returns>
	public static double Tone_Mapping_b_Abs_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_b : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("8a1a5755-a562-470b-9842-97b08791144c"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Tone_Mapping_b Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Tone_Mapping_c is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Tone_Mapping_c_Abs_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_c : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("e6d1fed4-c28a-431d-b9ec-0fce3566235a"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Tone_Mapping_c is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Tone_Mapping_c_Abs_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("e6d1fed4-c28a-431d-b9ec-0fce3566235a"), VCDGUIDs.VCDInterface_AbsoluteValue);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Tone_Mapping_c Property is not supported by current device.");
    }

	/// <summary>
	/// Set Tone_Mapping_c value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Tone_Mapping_c_Abs(TIS.Imaging.ICImagingControl ic, double Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_c : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("e6d1fed4-c28a-431d-b9ec-0fce3566235a"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Tone_Mapping_c Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Tone_Mapping_c : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Tone_Mapping_c Property is not supported by current device.");
	}

    /// <summary>
    /// Get Tone_Mapping_c value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Tone_Mapping_c</returns>
	public static double Tone_Mapping_c_Abs(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_c : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("e6d1fed4-c28a-431d-b9ec-0fce3566235a"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Tone_Mapping_c Property is not supported by current device.");
		
	}
	/// <summary>
    /// Get Tone_Mapping_c default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_c</returns>
	public static double Tone_Mapping_c_Abs_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_c : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("e6d1fed4-c28a-431d-b9ec-0fce3566235a"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Tone_Mapping_c Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_c minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_c</returns>
	public static double Tone_Mapping_c_Abs_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_c : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("e6d1fed4-c28a-431d-b9ec-0fce3566235a"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Tone_Mapping_c Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_c maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Tone_Mapping_c</returns>
	public static double Tone_Mapping_c_Abs_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_c : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("e6d1fed4-c28a-431d-b9ec-0fce3566235a"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Tone_Mapping_c Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Tone_Mapping_lum_avg is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Tone_Mapping_lum_avg_Abs_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_lum_avg : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("0634aea5-2a19-4292-97bc-7d228ae4c60f"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Tone_Mapping_lum_avg is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Tone_Mapping_lum_avg_Abs_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("0634aea5-2a19-4292-97bc-7d228ae4c60f"), VCDGUIDs.VCDInterface_AbsoluteValue);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Tone_Mapping_lum_avg Property is not supported by current device.");
    }

	/// <summary>
	/// Set Tone_Mapping_lum_avg value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Tone_Mapping_lum_avg_Abs(TIS.Imaging.ICImagingControl ic, double Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_lum_avg : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("0634aea5-2a19-4292-97bc-7d228ae4c60f"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Tone_Mapping_lum_avg Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Tone_Mapping_lum_avg : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Tone_Mapping_lum_avg Property is not supported by current device.");
	}

    /// <summary>
    /// Get Tone_Mapping_lum_avg value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Tone_Mapping_lum_avg</returns>
	public static double Tone_Mapping_lum_avg_Abs(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_lum_avg : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("0634aea5-2a19-4292-97bc-7d228ae4c60f"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Tone_Mapping_lum_avg Property is not supported by current device.");
		
	}
	/// <summary>
    /// Get Tone_Mapping_lum_avg default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_lum_avg</returns>
	public static double Tone_Mapping_lum_avg_Abs_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_lum_avg : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("0634aea5-2a19-4292-97bc-7d228ae4c60f"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Tone_Mapping_lum_avg Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_lum_avg minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_lum_avg</returns>
	public static double Tone_Mapping_lum_avg_Abs_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_lum_avg : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("0634aea5-2a19-4292-97bc-7d228ae4c60f"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Tone_Mapping_lum_avg Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_lum_avg maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Tone_Mapping_lum_avg</returns>
	public static double Tone_Mapping_lum_avg_Abs_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Tone_Mapping_lum_avg : No device selected");

		VCDAbsoluteValueProperty Property;
		Property = (VCDAbsoluteValueProperty)ic.VCDPropertyItems.FindInterface(new Guid("3d505ac4-1a28-428b-83e5-85aa8eb441c1"), new Guid("0634aea5-2a19-4292-97bc-7d228ae4c60f"), VCDGUIDs.VCDInterface_AbsoluteValue);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Tone_Mapping_lum_avg Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Partial_scan_Auto_center is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Partial_scan_Auto_center_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Partial_scan_Auto_center : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("36eaa683-3321-44be-9d73-e1fd4c3fdb87"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Partial_scan_Auto_center is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Partial_scan_Auto_center_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Partial_scan_Auto_center : No device selected");

        VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("36eaa683-3321-44be-9d73-e1fd4c3fdb87"), VCDGUIDs.VCDInterface_Switch);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Partial_scan_Auto_center Property is not supported by current device.");
    }

	/// <summary>
	/// Set Partial_scan_Auto_center value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="OnOff">Value to set</param>
	public static void Partial_scan_Auto_center(TIS.Imaging.ICImagingControl ic, bool OnOff )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Partial_scan_Auto_center : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("36eaa683-3321-44be-9d73-e1fd4c3fdb87"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Partial_scan_Auto_center Property is read only.");

                Property.Switch = OnOff;
		}
		else
            throw new System.Exception("Partial_scan_Auto_center Property is not supported by current device.");
	}

    /// <summary>
    /// Get Partial_scan_Auto_center value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Partial_scan_Auto_center</returns>
	public static bool Partial_scan_Auto_center(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Partial_scan_Auto_center : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("36eaa683-3321-44be-9d73-e1fd4c3fdb87"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
			return Property.Switch;
		}
		else
            throw new System.Exception("Partial_scan_Auto_center Property is not supported by current device.");
	}
	
	/// <summary>
    /// Check, whether Partial_scan_X_Offset is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Partial_scan_X_Offset_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Partial_scan_X_Offset : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("5e59f654-7b47-4458-b4c6-5d4f0d175fc1"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether Partial_scan_X_Offset is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Partial_scan_X_Offset_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("5e59f654-7b47-4458-b4c6-5d4f0d175fc1"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Partial_scan_X_Offset Property is not supported by current device.");
    }

	/// <summary>
	/// Set Partial_scan_X_Offset value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Partial_scan_X_Offset(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Partial_scan_X_Offset : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("5e59f654-7b47-4458-b4c6-5d4f0d175fc1"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Partial_scan_X_Offset Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Partial_scan_X_Offset : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Partial_scan_X_Offset Property is not supported by current device.");
	}

    /// <summary>
    /// Get Partial_scan_X_Offset value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Partial_scan_X_Offset</returns>
	public static int Partial_scan_X_Offset(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Partial_scan_X_Offset : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("5e59f654-7b47-4458-b4c6-5d4f0d175fc1"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Partial_scan_X_Offset Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Partial_scan_X_Offset default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of Partial_scan_X_Offset</returns>
	public static int Partial_scan_X_Offset_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Partial_scan_X_Offset : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("5e59f654-7b47-4458-b4c6-5d4f0d175fc1"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Partial_scan_X_Offset Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Partial_scan_X_Offset minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Partial_scan_X_Offset</returns>
	public static int Partial_scan_X_Offset_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Partial_scan_X_Offset : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("5e59f654-7b47-4458-b4c6-5d4f0d175fc1"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("Partial_scan_X_Offset Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Partial_scan_X_Offset maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Partial_scan_X_Offset</returns>
	public static int Partial_scan_X_Offset_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Partial_scan_X_Offset : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("5e59f654-7b47-4458-b4c6-5d4f0d175fc1"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Partial_scan_X_Offset Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Partial_scan_Y_Offset is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Partial_scan_Y_Offset_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Partial_scan_Y_Offset : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("87fb6c02-98a8-46b0-b18d-6442d9775cd3"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
			return true;
		else
			return false;

	}


	/// <summary>
    /// Returns, whether Partial_scan_Y_Offset is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Partial_scan_Y_Offset_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Black_Level : No device selected");

        VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("87fb6c02-98a8-46b0-b18d-6442d9775cd3"), VCDGUIDs.VCDInterface_Range);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Partial_scan_Y_Offset Property is not supported by current device.");
    }

	/// <summary>
	/// Set Partial_scan_Y_Offset value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="Value">Value to set</param>
	public static void Partial_scan_Y_Offset(TIS.Imaging.ICImagingControl ic, int Value )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Partial_scan_Y_Offset : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("87fb6c02-98a8-46b0-b18d-6442d9775cd3"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Partial_scan_Y_Offset Property is read only.");

            if (Property.RangeMin <= Value && Property.RangeMax >= Value)
                Property.Value = Value;
            else
                throw new System.Exception(System.String.Format( "Partial_scan_Y_Offset : Value {0} is not in range {1} - {2}.", Value, Property.RangeMin, Property.RangeMax ));
		}
		else
            throw new System.Exception("Partial_scan_Y_Offset Property is not supported by current device.");
	}

    /// <summary>
    /// Get Partial_scan_Y_Offset value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Partial_scan_Y_Offset</returns>
	public static int Partial_scan_Y_Offset(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Partial_scan_Y_Offset : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("87fb6c02-98a8-46b0-b18d-6442d9775cd3"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Value;
		}
		else
            throw new System.Exception("Partial_scan_Y_Offset Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Partial_scan_Y_Offset default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>default value of Partial_scan_Y_Offset</returns>
	public static int Partial_scan_Y_Offset_Default(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Partial_scan_Y_Offset : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("87fb6c02-98a8-46b0-b18d-6442d9775cd3"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.Default;
		}
		else
            throw new System.Exception("Partial_scan_Y_Offset Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Partial_scan_Y_Offset minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Partial_scan_Y_Offset</returns>
	public static int Partial_scan_Y_Offset_Min(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Partial_scan_Y_Offset : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("87fb6c02-98a8-46b0-b18d-6442d9775cd3"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMin;
		}
		else
            throw new System.Exception("Partial_scan_Y_Offset Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Partial_scan_Y_Offset maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Partial_scan_Y_Offset</returns>
	public static int Partial_scan_Y_Offset_Max(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Partial_scan_Y_Offset : No device selected");

		VCDRangeProperty Property;
		Property = (VCDRangeProperty)ic.VCDPropertyItems.FindInterface(new Guid("2ced6fd6-ab4d-4c74-904c-d682e53b9cc5"), new Guid("87fb6c02-98a8-46b0-b18d-6442d9775cd3"), VCDGUIDs.VCDInterface_Range);

		if( Property != null )
		{
			return Property.RangeMax;
		}
		else
            throw new System.Exception("Partial_scan_Y_Offset Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Strobe_Enable is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Strobe_Enable_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Strobe_Enable : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Strobe_Enable is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Strobe_Enable_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Strobe_Enable : No device selected");

        VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Strobe_Enable Property is not supported by current device.");
    }

	/// <summary>
	/// Set Strobe_Enable value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="OnOff">Value to set</param>
	public static void Strobe_Enable(TIS.Imaging.ICImagingControl ic, bool OnOff )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Strobe_Enable : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Strobe_Enable Property is read only.");

                Property.Switch = OnOff;
		}
		else
            throw new System.Exception("Strobe_Enable Property is not supported by current device.");
	}

    /// <summary>
    /// Get Strobe_Enable value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Strobe_Enable</returns>
	public static bool Strobe_Enable(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Strobe_Enable : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b57d3000-0ac6-4819-a609-272a33140aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
			return Property.Switch;
		}
		else
            throw new System.Exception("Strobe_Enable Property is not supported by current device.");
	}
    /// <summary>
    /// Check, whether Strobe_Mode is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
    public static bool Strobe_Mode_Avaialble(ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Strobe_Mode : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580acd"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
            return true;
        else
            return false;

    }

    /// <summary>
    /// Returns, whether Strobe_Mode is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Strobe_Mode_Readonly(ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580acd"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception("Strobe_Mode Property is not supported by current device.");

    }

    /// <summary>
    /// Get the current String value of Strobe_Mode
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <param name="StringValue">New value.</param>

    public static System.String Strobe_Mode(ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580acd"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            return Property.String;
        }
        else
            throw new System.Exception("Strobe_Mode Property is not supported by current device.");

    }

    /// <summary>
    /// Set a new String value to Strobe_Mode
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>Current string</returns>
    public static void Strobe_Mode(ICImagingControl ic, System.String StringValue)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580acd"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            bool ok = false;
            string AllowedValues = "";
            for( int i = 0; i < Property.Strings.Length && !ok; i++)
            {
                AllowedValues += " \"" + Property.Strings[i] + "\"";
                ok = (StringValue == Property.Strings[i]);
            }
            if( !ok)
                throw new System.Exception(System.String.Format("Strobe_Mode Property: Value \"{0}\" is not in list of {1}.", StringValue, AllowedValues));
            Property.String = StringValue;
        }
        else
            throw new System.Exception("Strobe_Mode Property is not supported by current device.");

    }

    /// <summary>
    /// Returns a String array with the list of avaialble Strings of Strobe_Mode
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>String []</returns>
    public static string[] Strobe_Mode_GetStrings(ICImagingControl ic )
    {
        if (!ic.DeviceValid)
            throw new System.Exception("#name : No device selected");

        VCDMapStringsProperty Property;
        Property = (VCDMapStringsProperty)ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580acd"), VCDGUIDs.VCDInterface_MapStrings);

        if (Property != null)
        {
            return Property.Strings;
        }
        else
            throw new System.Exception("Strobe_Mode Property is not supported by current device.");

    }

	
	/// <summary>
    /// Check, whether Strobe_Polarity is available for current device.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true : Available, false: not available</returns>
	public static bool Strobe_Polarity_Available(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Strobe_Polarity : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
			return true;
		else
			return false;
	}


	/// <summary>
    /// Returns, whether Strobe_Polarity is readonly.
    /// </summary>
    /// <param name="ic">>IC Imaging Control object</param>
    /// <returns>true: Property is ready only, false: Property is writeable</returns>
    public static bool Strobe_Polarity_Readonly(TIS.Imaging.ICImagingControl ic)
    {
        if (!ic.DeviceValid)
            throw new System.Exception("Strobe_Polarity : No device selected");

        VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580aca"), VCDGUIDs.VCDInterface_Switch);

        if (Property != null)
        {
            return Property.ReadOnly;
        }
        else
            throw new System.Exception(" Strobe_Polarity Property is not supported by current device.");
    }

	/// <summary>
	/// Set Strobe_Polarity value.
	/// </summary>
	/// <param name="ic">IC Imaging Control object</param>
	/// <param name="OnOff">Value to set</param>
	public static void Strobe_Polarity(TIS.Imaging.ICImagingControl ic, bool OnOff )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Strobe_Polarity : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
		     if( Property.ReadOnly)
                throw new System.Exception("Strobe_Polarity Property is read only.");

                Property.Switch = OnOff;
		}
		else
            throw new System.Exception("Strobe_Polarity Property is not supported by current device.");
	}

    /// <summary>
    /// Get Strobe_Polarity value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Current value of Strobe_Polarity</returns>
	public static bool Strobe_Polarity(TIS.Imaging.ICImagingControl ic )
	{
		if( !ic.DeviceValid)
			throw new System.Exception("Strobe_Polarity : No device selected");

		VCDSwitchProperty Property;
		Property = (VCDSwitchProperty)ic.VCDPropertyItems.FindInterface(new Guid("dc320ede-df2e-4a90-b926-71417c71c57c"), new Guid("b41db628-0975-43f8-a9d9-7e0380580aca"), VCDGUIDs.VCDInterface_Switch);

		if( Property != null )
		{
			return Property.Switch;
		}
		else
            throw new System.Exception("Strobe_Polarity Property is not supported by current device.");
	}

}
