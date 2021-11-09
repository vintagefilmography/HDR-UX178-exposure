// Include this file into your source code:
// Example:
// #include "icproperties.h"
//
// Example for setting a property ("Hue"):
/*
		try
		{
			ICProperties::Gain_Auto(&m_Grabber, false);
			ICProperties::Exposure_Auto(&m_Grabber, false);
			ICProperties::GainAbs(&m_Grabber, 0.0);
			double e = ICProperties::ExposureAbs(&m_Grabber);
			ICProperties::ExposureAbs(&m_Grabber,0.01);
			ICProperties::WhiteBalance_Auto(&m_Grabber, false);
			ICProperties::WhiteBalance_Blue(&m_Grabber, 10);
			ICProperties::WhiteBalance_One_Push(&m_Grabber);

			std::vector<std::wstring> wbpresets;

			wbpresets = ICProperties::WhiteBalance_Auto_Preset_GetStringsW(&m_Grabber );
		}
		catch (ICPropertyException ICPropex)
		{
			MessageBoxA(NULL, ICPropex.what(), "Property Error", MB_OK);
		}
*/

#ifndef __ICPROPERTIES__
	#define __ICPROPERTIES__

#include <exception>
#include "tisudshl.h"
#include <vector>

// C# Implemention of camera properties 

class ICPropertyException : public std::runtime_error
{
public:
	ICPropertyException(std::string const& msg) :
		std::runtime_error(msg)
	{}
};

class ICProperties
{
public:
	
	/// <summary>
    /// Check, whether Brightness is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Brightness_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Brightness : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e06-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Brightness is readonly.
    /// </summary>
    static bool Brightness_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Brightness : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e06-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Brightness Property is not supported by current device.");
    }

	/// <summary>
	/// Set Brightness value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Brightness(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Brightness : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e06-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Brightness Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Brightness : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Brightness Property is not supported by current device.");
	}

    /// <summary>
    /// Get Brightness value.
    /// </summary>
    /// <returns>Current value of Brightness</returns>
	static int Brightness(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Brightness : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e06-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Brightness Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Brightness defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Brightness</returns>
	static int Brightness_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Brightness : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e06-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Brightness Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get Brightness minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Brightness</returns>
	static int Brightness_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Brightness : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e06-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Brightness Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Brightness maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Brightness</returns>
	static int Brightness_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Brightness : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e06-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Brightness Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Contrast is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Contrast_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Contrast : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e07-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Contrast is readonly.
    /// </summary>
    static bool Contrast_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Contrast : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e07-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Contrast Property is not supported by current device.");
    }

	/// <summary>
	/// Set Contrast value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Contrast(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Contrast : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e07-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Contrast Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Contrast : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Contrast Property is not supported by current device.");
	}

    /// <summary>
    /// Get Contrast value.
    /// </summary>
    /// <returns>Current value of Contrast</returns>
	static int Contrast(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Contrast : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e07-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Contrast Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Contrast defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Contrast</returns>
	static int Contrast_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Contrast : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e07-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Contrast Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get Contrast minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Contrast</returns>
	static int Contrast_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Contrast : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e07-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Contrast Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Contrast maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Contrast</returns>
	static int Contrast_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Contrast : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e07-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Contrast Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Hue is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Hue_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Hue : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e08-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Hue is readonly.
    /// </summary>
    static bool Hue_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Hue : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e08-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Hue Property is not supported by current device.");
    }

	/// <summary>
	/// Set Hue value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Hue(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Hue : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e08-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Hue Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Hue : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Hue Property is not supported by current device.");
	}

    /// <summary>
    /// Get Hue value.
    /// </summary>
    /// <returns>Current value of Hue</returns>
	static int Hue(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Hue : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e08-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Hue Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Hue defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Hue</returns>
	static int Hue_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Hue : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e08-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Hue Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get Hue minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Hue</returns>
	static int Hue_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Hue : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e08-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Hue Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Hue maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Hue</returns>
	static int Hue_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Hue : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e08-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Hue Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Saturation is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Saturation_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Saturation : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e09-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Saturation is readonly.
    /// </summary>
    static bool Saturation_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Saturation : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e09-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Saturation Property is not supported by current device.");
    }

	/// <summary>
	/// Set Saturation value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Saturation(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Saturation : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e09-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Saturation Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Saturation : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Saturation Property is not supported by current device.");
	}

    /// <summary>
    /// Get Saturation value.
    /// </summary>
    /// <returns>Current value of Saturation</returns>
	static int Saturation(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Saturation : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e09-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Saturation Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Saturation defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Saturation</returns>
	static int Saturation_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Saturation : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e09-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Saturation Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get Saturation minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Saturation</returns>
	static int Saturation_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Saturation : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e09-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Saturation Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Saturation maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Saturation</returns>
	static int Saturation_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Saturation : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e09-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Saturation Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Sharpness is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Sharpness_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Sharpness : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0a-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Sharpness is readonly.
    /// </summary>
    static bool Sharpness_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Sharpness : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0a-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Sharpness Property is not supported by current device.");
    }

	/// <summary>
	/// Set Sharpness value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Sharpness(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Sharpness : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0a-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Sharpness Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Sharpness : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Sharpness Property is not supported by current device.");
	}

    /// <summary>
    /// Get Sharpness value.
    /// </summary>
    /// <returns>Current value of Sharpness</returns>
	static int Sharpness(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Sharpness : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0a-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Sharpness Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Sharpness defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Sharpness</returns>
	static int Sharpness_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Sharpness : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0a-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Sharpness Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get Sharpness minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Sharpness</returns>
	static int Sharpness_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Sharpness : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0a-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Sharpness Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Sharpness maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Sharpness</returns>
	static int Sharpness_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Sharpness : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0a-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Sharpness Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Gamma is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Gamma_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Gamma : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0b-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Gamma is readonly.
    /// </summary>
    static bool Gamma_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Gamma : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0b-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Gamma Property is not supported by current device.");
    }

	/// <summary>
	/// Set Gamma value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Gamma(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Gamma : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0b-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Gamma Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Gamma : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Gamma Property is not supported by current device.");
	}

    /// <summary>
    /// Get Gamma value.
    /// </summary>
    /// <returns>Current value of Gamma</returns>
	static int Gamma(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Gamma : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0b-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Gamma Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Gamma defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Gamma</returns>
	static int Gamma_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Gamma : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0b-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Gamma Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get Gamma minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Gamma</returns>
	static int Gamma_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Gamma : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0b-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Gamma Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Gamma maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Gamma</returns>
	static int Gamma_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Gamma : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0b-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Gamma Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether WhiteBalance_Auto is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool WhiteBalance_Auto_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Auto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3001-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether WhiteBalance_Auto is readonly.
    /// </summary>
    static bool WhiteBalance_Auto_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Auto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3001-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" WhiteBalance_Auto Property is not supported by current device.");
    }

	/// <summary>
	/// Set WhiteBalance_Auto value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void WhiteBalance_Auto(DShowLib::Grabber* pGrabber , bool Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Auto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3001-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("WhiteBalance_Auto Property is read only.");
			else
	            pProperty->setSwitch(Value);
		}
		else
            throw ICPropertyException("WhiteBalance_Auto Property is not supported by current device.");
	}

    /// <summary>
    /// Get WhiteBalance_Auto value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Auto</returns>
	static bool WhiteBalance_Auto(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Auto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3001-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getSwitch();
		}
		else
            throw ICPropertyException("WhiteBalance_Auto Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether WhiteBalance_One_Push is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool WhiteBalance_One_Push_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_One_Push : No device selected");

		DShowLib::tIVCDButtonPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3002-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether WhiteBalance_One_Push is readonly.
    /// </summary>
    static bool WhiteBalance_One_Push_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_One_Push : No device selected");

		DShowLib::tIVCDButtonPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		  pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3002-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" WhiteBalance_One_Push Property is not supported by current device.");
    }

    /// <summary>
    /// Get WhiteBalance_One_Push value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_One_Push</returns>
	static void WhiteBalance_One_Push(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_One_Push : No device selected");

		DShowLib::tIVCDButtonPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		  pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3002-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->push();
		}
		else
            throw ICPropertyException("WhiteBalance_One_Push Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether WhiteBalance_Mode is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool WhiteBalance_Mode_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Mode : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{ab98f78d-18a6-4eb2-a556-c11010ec9df7}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether WhiteBalance_Mode is readonly.
    /// </summary>
    static bool WhiteBalance_Mode_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Mode : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{ab98f78d-18a6-4eb2-a556-c11010ec9df7}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" WhiteBalance_Mode Property is not supported by current device.");
    }

	/// <summary>
	/// Set WhiteBalance_Mode value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void WhiteBalance_Mode(DShowLib::Grabber* pGrabber, std::string Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Mode : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{ab98f78d-18a6-4eb2-a556-c11010ec9df7}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("WhiteBalance_Mode Property is read only.");
			else
			{
				std::string ErrorMessage = "WhiteBalance_Mode : String \""+ Value + "\" is not in the list of available values: \"";
				bool bStringAllowed = false; 
				std::vector<std::string> StringList = pProperty->getStrings();
				for (unsigned int i = 0; i < StringList.size() && !bStringAllowed; i++)
				{
					if (i > 0)
						ErrorMessage += ", ";
					ErrorMessage += StringList[i] + " " ;

					if( Value == StringList[i])
						bStringAllowed = true;
				}
				if (bStringAllowed)
					pProperty->setString(Value);
				else
				{
					ErrorMessage += "\".";
					throw ICPropertyException(ErrorMessage);
				}
			}
		}
		else
            throw ICPropertyException("WhiteBalance_Mode Property is not supported by current device.");
	}

		/// <summary>
	/// Set WhiteBalance_Mode value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void WhiteBalance_Mode(DShowLib::Grabber* pGrabber, std::wstring Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Mode : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{ab98f78d-18a6-4eb2-a556-c11010ec9df7}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("WhiteBalance_Mode Property is read only.");
			else
			{
				std::wstring ErrorMessage = L"WhiteBalance_Mode : Tralala String \"" + Value;
				ErrorMessage += L"\" is not in the list of available values: \"";

				bool bStringAllowed = false;
				std::vector<std::wstring> StringList = pProperty->getStringsW();
				for (unsigned int i = 0; i < StringList.size() && !bStringAllowed; i++)
				{
					if (i > 0)
						ErrorMessage += L", ";
					ErrorMessage += StringList[i] + L" ";

					if (Value == StringList[i])
						bStringAllowed = true;
				}
				if (bStringAllowed)
					pProperty->setString(Value);
				else
				{
					ErrorMessage += L"\".";
					std::string s(DShowLib::wstoas(ErrorMessage.c_str()));

					throw ICPropertyException(s);
				}
			}
		}
		else
            throw ICPropertyException("WhiteBalance_Mode Property is not supported by current device.");
	}



    /// <summary>
    /// Get WhiteBalance_Mode value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Mode</returns>
	static  std::string WhiteBalance_Mode(DShowLib::Grabber* pGrabber)
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Mode : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{ab98f78d-18a6-4eb2-a556-c11010ec9df7}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getString();
		}
		else
            throw ICPropertyException("WhiteBalance_Mode Property is not supported by current device.");
		
	}
    /// <summary>
    /// Get WhiteBalance_Mode value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Mode</returns>
	static  std::wstring WhiteBalance_ModeW(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Mode : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{ab98f78d-18a6-4eb2-a556-c11010ec9df7}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getStringW();
		}
		else
            throw ICPropertyException("WhiteBalance_Mode Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Mode value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Mode</returns>
	static  std::vector<std::string> WhiteBalance_Mode_GetStrings(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Mode : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{ab98f78d-18a6-4eb2-a556-c11010ec9df7}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getStrings(); //tStringVec(Stringlist);
		}
		else
            throw ICPropertyException("WhiteBalance_Mode Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Mode value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Mode</returns>
	static  std::vector<std::wstring> WhiteBalance_Mode_GetStringsW(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Mode : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{ab98f78d-18a6-4eb2-a556-c11010ec9df7}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getStringsW(); //tStringVecW(Stringlist);
		}
		else
            throw ICPropertyException("WhiteBalance_Mode Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether WhiteBalance_Auto_Preset is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool WhiteBalance_Auto_Preset_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Auto_Preset : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{e5f037c5-a466-4f80-a717-3e506053274a}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether WhiteBalance_Auto_Preset is readonly.
    /// </summary>
    static bool WhiteBalance_Auto_Preset_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Auto_Preset : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{e5f037c5-a466-4f80-a717-3e506053274a}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" WhiteBalance_Auto_Preset Property is not supported by current device.");
    }

	/// <summary>
	/// Set WhiteBalance_Auto_Preset value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void WhiteBalance_Auto_Preset(DShowLib::Grabber* pGrabber, std::string Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Auto_Preset : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{e5f037c5-a466-4f80-a717-3e506053274a}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("WhiteBalance_Auto_Preset Property is read only.");
			else
			{
				std::string ErrorMessage = "WhiteBalance_Auto_Preset : String \""+ Value + "\" is not in the list of available values: \"";
				bool bStringAllowed = false; 
				std::vector<std::string> StringList = pProperty->getStrings();
				for (unsigned int i = 0; i < StringList.size() && !bStringAllowed; i++)
				{
					if (i > 0)
						ErrorMessage += ", ";
					ErrorMessage += StringList[i] + " " ;

					if( Value == StringList[i])
						bStringAllowed = true;
				}
				if (bStringAllowed)
					pProperty->setString(Value);
				else
				{
					ErrorMessage += "\".";
					throw ICPropertyException(ErrorMessage);
				}
			}
		}
		else
            throw ICPropertyException("WhiteBalance_Auto_Preset Property is not supported by current device.");
	}

		/// <summary>
	/// Set WhiteBalance_Auto_Preset value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void WhiteBalance_Auto_Preset(DShowLib::Grabber* pGrabber, std::wstring Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Auto_Preset : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{e5f037c5-a466-4f80-a717-3e506053274a}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("WhiteBalance_Auto_Preset Property is read only.");
			else
			{
				std::wstring ErrorMessage = L"WhiteBalance_Auto_Preset : Tralala String \"" + Value;
				ErrorMessage += L"\" is not in the list of available values: \"";

				bool bStringAllowed = false;
				std::vector<std::wstring> StringList = pProperty->getStringsW();
				for (unsigned int i = 0; i < StringList.size() && !bStringAllowed; i++)
				{
					if (i > 0)
						ErrorMessage += L", ";
					ErrorMessage += StringList[i] + L" ";

					if (Value == StringList[i])
						bStringAllowed = true;
				}
				if (bStringAllowed)
					pProperty->setString(Value);
				else
				{
					ErrorMessage += L"\".";
					std::string s(DShowLib::wstoas(ErrorMessage.c_str()));

					throw ICPropertyException(s);
				}
			}
		}
		else
            throw ICPropertyException("WhiteBalance_Auto_Preset Property is not supported by current device.");
	}



    /// <summary>
    /// Get WhiteBalance_Auto_Preset value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Auto_Preset</returns>
	static  std::string WhiteBalance_Auto_Preset(DShowLib::Grabber* pGrabber)
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Auto_Preset : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{e5f037c5-a466-4f80-a717-3e506053274a}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getString();
		}
		else
            throw ICPropertyException("WhiteBalance_Auto_Preset Property is not supported by current device.");
		
	}
    /// <summary>
    /// Get WhiteBalance_Auto_Preset value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Auto_Preset</returns>
	static  std::wstring WhiteBalance_Auto_PresetW(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Auto_Preset : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{e5f037c5-a466-4f80-a717-3e506053274a}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getStringW();
		}
		else
            throw ICPropertyException("WhiteBalance_Auto_Preset Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Auto_Preset value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Auto_Preset</returns>
	static  std::vector<std::string> WhiteBalance_Auto_Preset_GetStrings(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Auto_Preset : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{e5f037c5-a466-4f80-a717-3e506053274a}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getStrings(); //tStringVec(Stringlist);
		}
		else
            throw ICPropertyException("WhiteBalance_Auto_Preset Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Auto_Preset value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Auto_Preset</returns>
	static  std::vector<std::wstring> WhiteBalance_Auto_Preset_GetStringsW(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Auto_Preset : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{e5f037c5-a466-4f80-a717-3e506053274a}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getStringsW(); //tStringVecW(Stringlist);
		}
		else
            throw ICPropertyException("WhiteBalance_Auto_Preset Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether WhiteBalance_Temperature_Preset is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool WhiteBalance_Temperature_Preset_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Temperature_Preset : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{88143b6d-a1c5-45d6-bf7f-95f6447ab1be}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether WhiteBalance_Temperature_Preset is readonly.
    /// </summary>
    static bool WhiteBalance_Temperature_Preset_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Temperature_Preset : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{88143b6d-a1c5-45d6-bf7f-95f6447ab1be}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" WhiteBalance_Temperature_Preset Property is not supported by current device.");
    }

	/// <summary>
	/// Set WhiteBalance_Temperature_Preset value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void WhiteBalance_Temperature_Preset(DShowLib::Grabber* pGrabber, std::string Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Temperature_Preset : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{88143b6d-a1c5-45d6-bf7f-95f6447ab1be}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("WhiteBalance_Temperature_Preset Property is read only.");
			else
			{
				std::string ErrorMessage = "WhiteBalance_Temperature_Preset : String \""+ Value + "\" is not in the list of available values: \"";
				bool bStringAllowed = false; 
				std::vector<std::string> StringList = pProperty->getStrings();
				for (unsigned int i = 0; i < StringList.size() && !bStringAllowed; i++)
				{
					if (i > 0)
						ErrorMessage += ", ";
					ErrorMessage += StringList[i] + " " ;

					if( Value == StringList[i])
						bStringAllowed = true;
				}
				if (bStringAllowed)
					pProperty->setString(Value);
				else
				{
					ErrorMessage += "\".";
					throw ICPropertyException(ErrorMessage);
				}
			}
		}
		else
            throw ICPropertyException("WhiteBalance_Temperature_Preset Property is not supported by current device.");
	}

		/// <summary>
	/// Set WhiteBalance_Temperature_Preset value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void WhiteBalance_Temperature_Preset(DShowLib::Grabber* pGrabber, std::wstring Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Temperature_Preset : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{88143b6d-a1c5-45d6-bf7f-95f6447ab1be}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("WhiteBalance_Temperature_Preset Property is read only.");
			else
			{
				std::wstring ErrorMessage = L"WhiteBalance_Temperature_Preset : Tralala String \"" + Value;
				ErrorMessage += L"\" is not in the list of available values: \"";

				bool bStringAllowed = false;
				std::vector<std::wstring> StringList = pProperty->getStringsW();
				for (unsigned int i = 0; i < StringList.size() && !bStringAllowed; i++)
				{
					if (i > 0)
						ErrorMessage += L", ";
					ErrorMessage += StringList[i] + L" ";

					if (Value == StringList[i])
						bStringAllowed = true;
				}
				if (bStringAllowed)
					pProperty->setString(Value);
				else
				{
					ErrorMessage += L"\".";
					std::string s(DShowLib::wstoas(ErrorMessage.c_str()));

					throw ICPropertyException(s);
				}
			}
		}
		else
            throw ICPropertyException("WhiteBalance_Temperature_Preset Property is not supported by current device.");
	}



    /// <summary>
    /// Get WhiteBalance_Temperature_Preset value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Temperature_Preset</returns>
	static  std::string WhiteBalance_Temperature_Preset(DShowLib::Grabber* pGrabber)
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Temperature_Preset : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{88143b6d-a1c5-45d6-bf7f-95f6447ab1be}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getString();
		}
		else
            throw ICPropertyException("WhiteBalance_Temperature_Preset Property is not supported by current device.");
		
	}
    /// <summary>
    /// Get WhiteBalance_Temperature_Preset value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Temperature_Preset</returns>
	static  std::wstring WhiteBalance_Temperature_PresetW(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Temperature_Preset : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{88143b6d-a1c5-45d6-bf7f-95f6447ab1be}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getStringW();
		}
		else
            throw ICPropertyException("WhiteBalance_Temperature_Preset Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Temperature_Preset value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Temperature_Preset</returns>
	static  std::vector<std::string> WhiteBalance_Temperature_Preset_GetStrings(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Temperature_Preset : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{88143b6d-a1c5-45d6-bf7f-95f6447ab1be}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getStrings(); //tStringVec(Stringlist);
		}
		else
            throw ICPropertyException("WhiteBalance_Temperature_Preset Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Temperature_Preset value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Temperature_Preset</returns>
	static  std::vector<std::wstring> WhiteBalance_Temperature_Preset_GetStringsW(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Temperature_Preset : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{88143b6d-a1c5-45d6-bf7f-95f6447ab1be}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getStringsW(); //tStringVecW(Stringlist);
		}
		else
            throw ICPropertyException("WhiteBalance_Temperature_Preset Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether WhiteBalance_Temperature is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool WhiteBalance_Temperature_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Temperature : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b8d65671-94e0-4dbb-9275-0c29d4f6ba87}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether WhiteBalance_Temperature is readonly.
    /// </summary>
    static bool WhiteBalance_Temperature_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Temperature : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b8d65671-94e0-4dbb-9275-0c29d4f6ba87}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" WhiteBalance_Temperature Property is not supported by current device.");
    }

	/// <summary>
	/// Set WhiteBalance_Temperature value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void WhiteBalance_Temperature(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Temperature : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b8d65671-94e0-4dbb-9275-0c29d4f6ba87}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("WhiteBalance_Temperature Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"WhiteBalance_Temperature : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("WhiteBalance_Temperature Property is not supported by current device.");
	}

    /// <summary>
    /// Get WhiteBalance_Temperature value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Temperature</returns>
	static int WhiteBalance_Temperature(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Temperature : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b8d65671-94e0-4dbb-9275-0c29d4f6ba87}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("WhiteBalance_Temperature Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get WhiteBalance_Temperature defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of WhiteBalance_Temperature</returns>
	static int WhiteBalance_Temperature_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Temperature : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b8d65671-94e0-4dbb-9275-0c29d4f6ba87}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("WhiteBalance_Temperature Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get WhiteBalance_Temperature minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of WhiteBalance_Temperature</returns>
	static int WhiteBalance_Temperature_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Temperature : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b8d65671-94e0-4dbb-9275-0c29d4f6ba87}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("WhiteBalance_Temperature Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Temperature maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of WhiteBalance_Temperature</returns>
	static int WhiteBalance_Temperature_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("WhiteBalance_Temperature : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b8d65671-94e0-4dbb-9275-0c29d4f6ba87}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("WhiteBalance_Temperature Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether WhiteBalance_Red is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool WhiteBalance_Red_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Red : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{6519038b-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether WhiteBalance_Red is readonly.
    /// </summary>
    static bool WhiteBalance_Red_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Red : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{6519038b-1ad8-4e91-9021-66d64090cc85}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" WhiteBalance_Red Property is not supported by current device.");
    }

	/// <summary>
	/// Set WhiteBalance_Red value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void WhiteBalance_Red(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Red : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{6519038b-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("WhiteBalance_Red Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"WhiteBalance_Red : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("WhiteBalance_Red Property is not supported by current device.");
	}

    /// <summary>
    /// Get WhiteBalance_Red value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Red</returns>
	static int WhiteBalance_Red(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Red : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{6519038b-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("WhiteBalance_Red Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get WhiteBalance_Red defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of WhiteBalance_Red</returns>
	static int WhiteBalance_Red_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Red : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{6519038b-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("WhiteBalance_Red Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get WhiteBalance_Red minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of WhiteBalance_Red</returns>
	static int WhiteBalance_Red_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Red : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{6519038b-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("WhiteBalance_Red Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Red maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of WhiteBalance_Red</returns>
	static int WhiteBalance_Red_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("WhiteBalance_Red : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{6519038b-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("WhiteBalance_Red Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether WhiteBalance_Green is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool WhiteBalance_Green_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Green : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{8407e480-175a-498c-8171-08bd987cc1ac}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether WhiteBalance_Green is readonly.
    /// </summary>
    static bool WhiteBalance_Green_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Green : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{8407e480-175a-498c-8171-08bd987cc1ac}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" WhiteBalance_Green Property is not supported by current device.");
    }

	/// <summary>
	/// Set WhiteBalance_Green value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void WhiteBalance_Green(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Green : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{8407e480-175a-498c-8171-08bd987cc1ac}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("WhiteBalance_Green Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"WhiteBalance_Green : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("WhiteBalance_Green Property is not supported by current device.");
	}

    /// <summary>
    /// Get WhiteBalance_Green value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Green</returns>
	static int WhiteBalance_Green(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Green : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{8407e480-175a-498c-8171-08bd987cc1ac}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("WhiteBalance_Green Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get WhiteBalance_Green defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of WhiteBalance_Green</returns>
	static int WhiteBalance_Green_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Green : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{8407e480-175a-498c-8171-08bd987cc1ac}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("WhiteBalance_Green Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get WhiteBalance_Green minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of WhiteBalance_Green</returns>
	static int WhiteBalance_Green_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Green : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{8407e480-175a-498c-8171-08bd987cc1ac}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("WhiteBalance_Green Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Green maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of WhiteBalance_Green</returns>
	static int WhiteBalance_Green_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("WhiteBalance_Green : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{8407e480-175a-498c-8171-08bd987cc1ac}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("WhiteBalance_Green Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether WhiteBalance_Blue is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool WhiteBalance_Blue_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Blue : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{6519038a-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether WhiteBalance_Blue is readonly.
    /// </summary>
    static bool WhiteBalance_Blue_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Blue : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{6519038a-1ad8-4e91-9021-66d64090cc85}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" WhiteBalance_Blue Property is not supported by current device.");
    }

	/// <summary>
	/// Set WhiteBalance_Blue value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void WhiteBalance_Blue(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Blue : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{6519038a-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("WhiteBalance_Blue Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"WhiteBalance_Blue : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("WhiteBalance_Blue Property is not supported by current device.");
	}

    /// <summary>
    /// Get WhiteBalance_Blue value.
    /// </summary>
    /// <returns>Current value of WhiteBalance_Blue</returns>
	static int WhiteBalance_Blue(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Blue : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{6519038a-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("WhiteBalance_Blue Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get WhiteBalance_Blue defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of WhiteBalance_Blue</returns>
	static int WhiteBalance_Blue_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Blue : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{6519038a-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("WhiteBalance_Blue Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get WhiteBalance_Blue minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of WhiteBalance_Blue</returns>
	static int WhiteBalance_Blue_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("WhiteBalance_Blue : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{6519038a-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("WhiteBalance_Blue Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get WhiteBalance_Blue maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of WhiteBalance_Blue</returns>
	static int WhiteBalance_Blue_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("WhiteBalance_Blue : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0d-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{6519038a-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("WhiteBalance_Blue Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Gain is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Gain_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Gain : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0f-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Gain is readonly.
    /// </summary>
    static bool Gain_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Gain : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0f-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Gain Property is not supported by current device.");
    }

	/// <summary>
	/// Set Gain value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Gain(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Gain : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0f-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Gain Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Gain : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Gain Property is not supported by current device.");
	}

    /// <summary>
    /// Get Gain value.
    /// </summary>
    /// <returns>Current value of Gain</returns>
	static int Gain(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Gain : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0f-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Gain Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Gain defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Gain</returns>
	static int Gain_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Gain : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0f-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Gain Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get Gain minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Gain</returns>
	static int Gain_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Gain : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0f-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Gain Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Gain maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Gain</returns>
	static int Gain_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Gain : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0f-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Gain Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Gain_Auto is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Gain_Auto_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Gain_Auto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0f-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3001-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Gain_Auto is readonly.
    /// </summary>
    static bool Gain_Auto_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Gain_Auto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0f-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3001-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Gain_Auto Property is not supported by current device.");
    }

	/// <summary>
	/// Set Gain_Auto value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Gain_Auto(DShowLib::Grabber* pGrabber , bool Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Gain_Auto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0f-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3001-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("Gain_Auto Property is read only.");
			else
	            pProperty->setSwitch(Value);
		}
		else
            throw ICPropertyException("Gain_Auto Property is not supported by current device.");
	}

    /// <summary>
    /// Get Gain_Auto value.
    /// </summary>
    /// <returns>Current value of Gain_Auto</returns>
	static bool Gain_Auto(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Gain_Auto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{284c0e0f-010b-45bf-8291-09d90a459b28}"), DShowLib::StringToGUID(L"{b57d3001-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getSwitch();
		}
		else
            throw ICPropertyException("Gain_Auto Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Exposure is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Exposure_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Exposure is readonly.
    /// </summary>
    static bool Exposure_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Exposure Property is not supported by current device.");
    }

	/// <summary>
	/// Set Exposure value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Exposure(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Exposure Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Exposure : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Exposure Property is not supported by current device.");
	}

    /// <summary>
    /// Get Exposure value.
    /// </summary>
    /// <returns>Current value of Exposure</returns>
	static int Exposure(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Exposure Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Exposure defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure</returns>
	static int Exposure_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Exposure Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get Exposure minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure</returns>
	static int Exposure_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Exposure Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Exposure</returns>
	static int Exposure_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Exposure : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Exposure Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Exposure is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Exposure_Abs_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Exposure is readonly.
    /// </summary>
    static bool Exposure_Abs_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Exposure Property is not supported by current device.");
    }

	/// <summary>
	/// Set Exposure value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Exposure_Abs(DShowLib::Grabber* pGrabber , double Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Exposure Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Exposure : Value %f is not in range %f - %f.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Exposure Property is not supported by current device.");
	}

    /// <summary>
    /// Get Exposure value.
    /// </summary>
    /// <returns>Current value of Exposure</returns>
	static double Exposure_Abs(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Exposure Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Exposure default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure</returns>
	static double Exposure_Abs_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Exposure Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure</returns>
	static double Exposure_Abs_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Exposure Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Exposure</returns>
	static double Exposure_Abs_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Exposure : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);


		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Exposure Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Exposure_Auto is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Exposure_Auto_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3001-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Exposure_Auto is readonly.
    /// </summary>
    static bool Exposure_Auto_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3001-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Exposure_Auto Property is not supported by current device.");
    }

	/// <summary>
	/// Set Exposure_Auto value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Exposure_Auto(DShowLib::Grabber* pGrabber , bool Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3001-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("Exposure_Auto Property is read only.");
			else
	            pProperty->setSwitch(Value);
		}
		else
            throw ICPropertyException("Exposure_Auto Property is not supported by current device.");
	}

    /// <summary>
    /// Get Exposure_Auto value.
    /// </summary>
    /// <returns>Current value of Exposure_Auto</returns>
	static bool Exposure_Auto(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3001-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getSwitch();
		}
		else
            throw ICPropertyException("Exposure_Auto Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Exposure_Auto_Reference is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Exposure_Auto_Reference_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Reference : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038c-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Exposure_Auto_Reference is readonly.
    /// </summary>
    static bool Exposure_Auto_Reference_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Reference : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038c-1ad8-4e91-9021-66d64090cc85}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Exposure_Auto_Reference Property is not supported by current device.");
    }

	/// <summary>
	/// Set Exposure_Auto_Reference value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Exposure_Auto_Reference(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Reference : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038c-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Exposure_Auto_Reference Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Exposure_Auto_Reference : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Exposure_Auto_Reference Property is not supported by current device.");
	}

    /// <summary>
    /// Get Exposure_Auto_Reference value.
    /// </summary>
    /// <returns>Current value of Exposure_Auto_Reference</returns>
	static int Exposure_Auto_Reference(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Reference : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038c-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Exposure_Auto_Reference Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Exposure_Auto_Reference defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure_Auto_Reference</returns>
	static int Exposure_Auto_Reference_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Reference : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038c-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Exposure_Auto_Reference Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get Exposure_Auto_Reference minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure_Auto_Reference</returns>
	static int Exposure_Auto_Reference_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Reference : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038c-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Exposure_Auto_Reference Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure_Auto_Reference maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Exposure_Auto_Reference</returns>
	static int Exposure_Auto_Reference_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Exposure_Auto_Reference : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038c-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Exposure_Auto_Reference Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Exposure_Auto_Max_Value is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Exposure_Auto_Max_Value_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Max_Value : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038f-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Exposure_Auto_Max_Value is readonly.
    /// </summary>
    static bool Exposure_Auto_Max_Value_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Max_Value : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038f-1ad8-4e91-9021-66d64090cc85}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Exposure_Auto_Max_Value Property is not supported by current device.");
    }

	/// <summary>
	/// Set Exposure_Auto_Max_Value value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Exposure_Auto_Max_Value(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Max_Value : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038f-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Exposure_Auto_Max_Value Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Exposure_Auto_Max_Value : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Exposure_Auto_Max_Value Property is not supported by current device.");
	}

    /// <summary>
    /// Get Exposure_Auto_Max_Value value.
    /// </summary>
    /// <returns>Current value of Exposure_Auto_Max_Value</returns>
	static int Exposure_Auto_Max_Value(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Max_Value : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038f-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Exposure_Auto_Max_Value Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Exposure_Auto_Max_Value defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure_Auto_Max_Value</returns>
	static int Exposure_Auto_Max_Value_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Max_Value : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038f-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Exposure_Auto_Max_Value Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get Exposure_Auto_Max_Value minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure_Auto_Max_Value</returns>
	static int Exposure_Auto_Max_Value_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Max_Value : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038f-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Exposure_Auto_Max_Value Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure_Auto_Max_Value maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Exposure_Auto_Max_Value</returns>
	static int Exposure_Auto_Max_Value_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Exposure_Auto_Max_Value : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038f-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Exposure_Auto_Max_Value Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Exposure_Auto_Max_Value is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Exposure_Auto_Max_Value_Abs_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Max_Value : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038f-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Exposure_Auto_Max_Value is readonly.
    /// </summary>
    static bool Exposure_Auto_Max_Value_Abs_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Max_Value : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038f-1ad8-4e91-9021-66d64090cc85}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Exposure_Auto_Max_Value Property is not supported by current device.");
    }

	/// <summary>
	/// Set Exposure_Auto_Max_Value value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Exposure_Auto_Max_Value_Abs(DShowLib::Grabber* pGrabber , double Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Max_Value : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038f-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Exposure_Auto_Max_Value Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Exposure_Auto_Max_Value : Value %f is not in range %f - %f.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Exposure_Auto_Max_Value Property is not supported by current device.");
	}

    /// <summary>
    /// Get Exposure_Auto_Max_Value value.
    /// </summary>
    /// <returns>Current value of Exposure_Auto_Max_Value</returns>
	static double Exposure_Auto_Max_Value_Abs(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Max_Value : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038f-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Exposure_Auto_Max_Value Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Exposure_Auto_Max_Value default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure_Auto_Max_Value</returns>
	static double Exposure_Auto_Max_Value_Abs_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Max_Value : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038f-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Exposure_Auto_Max_Value Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure_Auto_Max_Value minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Exposure_Auto_Max_Value</returns>
	static double Exposure_Auto_Max_Value_Abs_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_Auto_Max_Value : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038f-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Exposure_Auto_Max_Value Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Exposure_Auto_Max_Value maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Exposure_Auto_Max_Value</returns>
	static double Exposure_Auto_Max_Value_Abs_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Exposure_Auto_Max_Value : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{6519038f-1ad8-4e91-9021-66d64090cc85}"),pProperty);


		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Exposure_Auto_Max_Value Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Exposure_MaxAutoAuto is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Exposure_MaxAutoAuto_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_MaxAutoAuto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{65190390-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Exposure_MaxAutoAuto is readonly.
    /// </summary>
    static bool Exposure_MaxAutoAuto_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_MaxAutoAuto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{65190390-1ad8-4e91-9021-66d64090cc85}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Exposure_MaxAutoAuto Property is not supported by current device.");
    }

	/// <summary>
	/// Set Exposure_MaxAutoAuto value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Exposure_MaxAutoAuto(DShowLib::Grabber* pGrabber , bool Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_MaxAutoAuto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{65190390-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("Exposure_MaxAutoAuto Property is read only.");
			else
	            pProperty->setSwitch(Value);
		}
		else
            throw ICPropertyException("Exposure_MaxAutoAuto Property is not supported by current device.");
	}

    /// <summary>
    /// Get Exposure_MaxAutoAuto value.
    /// </summary>
    /// <returns>Current value of Exposure_MaxAutoAuto</returns>
	static bool Exposure_MaxAutoAuto(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Exposure_MaxAutoAuto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d5702e-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{65190390-1ad8-4e91-9021-66d64090cc85}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getSwitch();
		}
		else
            throw ICPropertyException("Exposure_MaxAutoAuto Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Trigger_Enable is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Trigger_Enable_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Trigger_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d57031-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Trigger_Enable is readonly.
    /// </summary>
    static bool Trigger_Enable_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Trigger_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d57031-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Trigger_Enable Property is not supported by current device.");
    }

	/// <summary>
	/// Set Trigger_Enable value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Trigger_Enable(DShowLib::Grabber* pGrabber , bool Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Trigger_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d57031-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("Trigger_Enable Property is read only.");
			else
	            pProperty->setSwitch(Value);
		}
		else
            throw ICPropertyException("Trigger_Enable Property is not supported by current device.");
	}

    /// <summary>
    /// Get Trigger_Enable value.
    /// </summary>
    /// <returns>Current value of Trigger_Enable</returns>
	static bool Trigger_Enable(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Trigger_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d57031-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getSwitch();
		}
		else
            throw ICPropertyException("Trigger_Enable Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Trigger_Software is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Trigger_Software_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Trigger_Software : No device selected");

		DShowLib::tIVCDButtonPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d57031-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{fdb4003c-552c-4faa-b87b-42e888d54147}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Trigger_Software is readonly.
    /// </summary>
    static bool Trigger_Software_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Trigger_Software : No device selected");

		DShowLib::tIVCDButtonPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		  pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d57031-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{fdb4003c-552c-4faa-b87b-42e888d54147}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Trigger_Software Property is not supported by current device.");
    }

    /// <summary>
    /// Get Trigger_Software value.
    /// </summary>
    /// <returns>Current value of Trigger_Software</returns>
	static void Trigger_Software(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Trigger_Software : No device selected");

		DShowLib::tIVCDButtonPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		  pItems->findInterfacePtr(DShowLib::StringToGUID(L"{90d57031-e43b-4366-aaeb-7a7a10b448b4}"), DShowLib::StringToGUID(L"{fdb4003c-552c-4faa-b87b-42e888d54147}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->push();
		}
		else
            throw ICPropertyException("Trigger_Software Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Denoise is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Denoise_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Denoise : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{c3c9944a-e6f6-4e25-a0be-53c066ab65d8}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Denoise is readonly.
    /// </summary>
    static bool Denoise_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Denoise : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{c3c9944a-e6f6-4e25-a0be-53c066ab65d8}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Denoise Property is not supported by current device.");
    }

	/// <summary>
	/// Set Denoise value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Denoise(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Denoise : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{c3c9944a-e6f6-4e25-a0be-53c066ab65d8}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Denoise Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Denoise : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Denoise Property is not supported by current device.");
	}

    /// <summary>
    /// Get Denoise value.
    /// </summary>
    /// <returns>Current value of Denoise</returns>
	static int Denoise(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Denoise : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{c3c9944a-e6f6-4e25-a0be-53c066ab65d8}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Denoise Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Denoise defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Denoise</returns>
	static int Denoise_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Denoise : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{c3c9944a-e6f6-4e25-a0be-53c066ab65d8}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Denoise Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get Denoise minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Denoise</returns>
	static int Denoise_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Denoise : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{c3c9944a-e6f6-4e25-a0be-53c066ab65d8}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Denoise Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Denoise maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Denoise</returns>
	static int Denoise_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Denoise : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{c3c9944a-e6f6-4e25-a0be-53c066ab65d8}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Denoise Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether GPIO_GP_IN is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool GPIO_GP_IN_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_GP_IN : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a500}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether GPIO_GP_IN is readonly.
    /// </summary>
    static bool GPIO_GP_IN_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_GP_IN : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a500}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" GPIO_GP_IN Property is not supported by current device.");
    }

	/// <summary>
	/// Set GPIO_GP_IN value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void GPIO_GP_IN(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_GP_IN : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a500}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("GPIO_GP_IN Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"GPIO_GP_IN : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("GPIO_GP_IN Property is not supported by current device.");
	}

    /// <summary>
    /// Get GPIO_GP_IN value.
    /// </summary>
    /// <returns>Current value of GPIO_GP_IN</returns>
	static int GPIO_GP_IN(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_GP_IN : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a500}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("GPIO_GP_IN Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get GPIO_GP_IN defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of GPIO_GP_IN</returns>
	static int GPIO_GP_IN_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_GP_IN : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a500}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("GPIO_GP_IN Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get GPIO_GP_IN minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of GPIO_GP_IN</returns>
	static int GPIO_GP_IN_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_GP_IN : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a500}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("GPIO_GP_IN Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get GPIO_GP_IN maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of GPIO_GP_IN</returns>
	static int GPIO_GP_IN_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("GPIO_GP_IN : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a500}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("GPIO_GP_IN Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether GPIO_Read is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool GPIO_Read_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_Read : No device selected");

		DShowLib::tIVCDButtonPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a503}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether GPIO_Read is readonly.
    /// </summary>
    static bool GPIO_Read_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_Read : No device selected");

		DShowLib::tIVCDButtonPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		  pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a503}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" GPIO_Read Property is not supported by current device.");
    }

    /// <summary>
    /// Get GPIO_Read value.
    /// </summary>
    /// <returns>Current value of GPIO_Read</returns>
	static void GPIO_Read(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_Read : No device selected");

		DShowLib::tIVCDButtonPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		  pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a503}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->push();
		}
		else
            throw ICPropertyException("GPIO_Read Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether GPIO_GP_Out is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool GPIO_GP_Out_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_GP_Out : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a501}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether GPIO_GP_Out is readonly.
    /// </summary>
    static bool GPIO_GP_Out_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_GP_Out : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a501}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" GPIO_GP_Out Property is not supported by current device.");
    }

	/// <summary>
	/// Set GPIO_GP_Out value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void GPIO_GP_Out(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_GP_Out : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a501}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("GPIO_GP_Out Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"GPIO_GP_Out : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("GPIO_GP_Out Property is not supported by current device.");
	}

    /// <summary>
    /// Get GPIO_GP_Out value.
    /// </summary>
    /// <returns>Current value of GPIO_GP_Out</returns>
	static int GPIO_GP_Out(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_GP_Out : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a501}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("GPIO_GP_Out Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get GPIO_GP_Out defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of GPIO_GP_Out</returns>
	static int GPIO_GP_Out_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_GP_Out : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a501}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("GPIO_GP_Out Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get GPIO_GP_Out minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of GPIO_GP_Out</returns>
	static int GPIO_GP_Out_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_GP_Out : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a501}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("GPIO_GP_Out Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get GPIO_GP_Out maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of GPIO_GP_Out</returns>
	static int GPIO_GP_Out_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("GPIO_GP_Out : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a501}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("GPIO_GP_Out Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether GPIO_Write is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool GPIO_Write_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_Write : No device selected");

		DShowLib::tIVCDButtonPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a502}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether GPIO_Write is readonly.
    /// </summary>
    static bool GPIO_Write_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_Write : No device selected");

		DShowLib::tIVCDButtonPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		  pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a502}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" GPIO_Write Property is not supported by current device.");
    }

    /// <summary>
    /// Get GPIO_Write value.
    /// </summary>
    /// <returns>Current value of GPIO_Write</returns>
	static void GPIO_Write(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("GPIO_Write : No device selected");

		DShowLib::tIVCDButtonPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		  pItems->findInterfacePtr(DShowLib::StringToGUID(L"{86d89d69-9880-4618-9bf6-ded5e8383449}"), DShowLib::StringToGUID(L"{7d006621-761d-4b88-9c5f-8b906857a502}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->push();
		}
		else
            throw ICPropertyException("GPIO_Write Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Binning_factor is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Binning_factor_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Binning_factor : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{4f95a06d-9c15-407b-96ab-cf3fed047ba4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Binning_factor is readonly.
    /// </summary>
    static bool Binning_factor_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Binning_factor : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{4f95a06d-9c15-407b-96ab-cf3fed047ba4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Binning_factor Property is not supported by current device.");
    }

	/// <summary>
	/// Set Binning_factor value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Binning_factor(DShowLib::Grabber* pGrabber, std::string Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Binning_factor : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{4f95a06d-9c15-407b-96ab-cf3fed047ba4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("Binning_factor Property is read only.");
			else
			{
				std::string ErrorMessage = "Binning_factor : String \""+ Value + "\" is not in the list of available values: \"";
				bool bStringAllowed = false; 
				std::vector<std::string> StringList = pProperty->getStrings();
				for (unsigned int i = 0; i < StringList.size() && !bStringAllowed; i++)
				{
					if (i > 0)
						ErrorMessage += ", ";
					ErrorMessage += StringList[i] + " " ;

					if( Value == StringList[i])
						bStringAllowed = true;
				}
				if (bStringAllowed)
					pProperty->setString(Value);
				else
				{
					ErrorMessage += "\".";
					throw ICPropertyException(ErrorMessage);
				}
			}
		}
		else
            throw ICPropertyException("Binning_factor Property is not supported by current device.");
	}

		/// <summary>
	/// Set Binning_factor value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Binning_factor(DShowLib::Grabber* pGrabber, std::wstring Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Binning_factor : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{4f95a06d-9c15-407b-96ab-cf3fed047ba4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("Binning_factor Property is read only.");
			else
			{
				std::wstring ErrorMessage = L"Binning_factor : Tralala String \"" + Value;
				ErrorMessage += L"\" is not in the list of available values: \"";

				bool bStringAllowed = false;
				std::vector<std::wstring> StringList = pProperty->getStringsW();
				for (unsigned int i = 0; i < StringList.size() && !bStringAllowed; i++)
				{
					if (i > 0)
						ErrorMessage += L", ";
					ErrorMessage += StringList[i] + L" ";

					if (Value == StringList[i])
						bStringAllowed = true;
				}
				if (bStringAllowed)
					pProperty->setString(Value);
				else
				{
					ErrorMessage += L"\".";
					std::string s(DShowLib::wstoas(ErrorMessage.c_str()));

					throw ICPropertyException(s);
				}
			}
		}
		else
            throw ICPropertyException("Binning_factor Property is not supported by current device.");
	}



    /// <summary>
    /// Get Binning_factor value.
    /// </summary>
    /// <returns>Current value of Binning_factor</returns>
	static  std::string Binning_factor(DShowLib::Grabber* pGrabber)
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Binning_factor : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{4f95a06d-9c15-407b-96ab-cf3fed047ba4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getString();
		}
		else
            throw ICPropertyException("Binning_factor Property is not supported by current device.");
		
	}
    /// <summary>
    /// Get Binning_factor value.
    /// </summary>
    /// <returns>Current value of Binning_factor</returns>
	static  std::wstring Binning_factorW(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Binning_factor : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{4f95a06d-9c15-407b-96ab-cf3fed047ba4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getStringW();
		}
		else
            throw ICPropertyException("Binning_factor Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Binning_factor value.
    /// </summary>
    /// <returns>Current value of Binning_factor</returns>
	static  std::vector<std::string> Binning_factor_GetStrings(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Binning_factor : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{4f95a06d-9c15-407b-96ab-cf3fed047ba4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getStrings(); //tStringVec(Stringlist);
		}
		else
            throw ICPropertyException("Binning_factor Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Binning_factor value.
    /// </summary>
    /// <returns>Current value of Binning_factor</returns>
	static  std::vector<std::wstring> Binning_factor_GetStringsW(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Binning_factor : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{4f95a06d-9c15-407b-96ab-cf3fed047ba4}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getStringsW(); //tStringVecW(Stringlist);
		}
		else
            throw ICPropertyException("Binning_factor Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Color_Enhancement_Enable is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Color_Enhancement_Enable_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Color_Enhancement_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3a3a8f77-6440-46cc-940a-8752b02e6c29}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Color_Enhancement_Enable is readonly.
    /// </summary>
    static bool Color_Enhancement_Enable_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Color_Enhancement_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3a3a8f77-6440-46cc-940a-8752b02e6c29}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Color_Enhancement_Enable Property is not supported by current device.");
    }

	/// <summary>
	/// Set Color_Enhancement_Enable value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Color_Enhancement_Enable(DShowLib::Grabber* pGrabber , bool Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Color_Enhancement_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3a3a8f77-6440-46cc-940a-8752b02e6c29}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("Color_Enhancement_Enable Property is read only.");
			else
	            pProperty->setSwitch(Value);
		}
		else
            throw ICPropertyException("Color_Enhancement_Enable Property is not supported by current device.");
	}

    /// <summary>
    /// Get Color_Enhancement_Enable value.
    /// </summary>
    /// <returns>Current value of Color_Enhancement_Enable</returns>
	static bool Color_Enhancement_Enable(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Color_Enhancement_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3a3a8f77-6440-46cc-940a-8752b02e6c29}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getSwitch();
		}
		else
            throw ICPropertyException("Color_Enhancement_Enable Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Highlight_reduction_Enable is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Highlight_reduction_Enable_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Highlight_reduction_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{546541ad-c815-4d82-afa9-9d59af9f399e}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Highlight_reduction_Enable is readonly.
    /// </summary>
    static bool Highlight_reduction_Enable_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Highlight_reduction_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{546541ad-c815-4d82-afa9-9d59af9f399e}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Highlight_reduction_Enable Property is not supported by current device.");
    }

	/// <summary>
	/// Set Highlight_reduction_Enable value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Highlight_reduction_Enable(DShowLib::Grabber* pGrabber , bool Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Highlight_reduction_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{546541ad-c815-4d82-afa9-9d59af9f399e}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("Highlight_reduction_Enable Property is read only.");
			else
	            pProperty->setSwitch(Value);
		}
		else
            throw ICPropertyException("Highlight_reduction_Enable Property is not supported by current device.");
	}

    /// <summary>
    /// Get Highlight_reduction_Enable value.
    /// </summary>
    /// <returns>Current value of Highlight_reduction_Enable</returns>
	static bool Highlight_reduction_Enable(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Highlight_reduction_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{546541ad-c815-4d82-afa9-9d59af9f399e}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getSwitch();
		}
		else
            throw ICPropertyException("Highlight_reduction_Enable Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Tone_Mapping_Enable is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Tone_Mapping_Enable_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Tone_Mapping_Enable is readonly.
    /// </summary>
    static bool Tone_Mapping_Enable_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Tone_Mapping_Enable Property is not supported by current device.");
    }

	/// <summary>
	/// Set Tone_Mapping_Enable value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Tone_Mapping_Enable(DShowLib::Grabber* pGrabber , bool Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("Tone_Mapping_Enable Property is read only.");
			else
	            pProperty->setSwitch(Value);
		}
		else
            throw ICPropertyException("Tone_Mapping_Enable Property is not supported by current device.");
	}

    /// <summary>
    /// Get Tone_Mapping_Enable value.
    /// </summary>
    /// <returns>Current value of Tone_Mapping_Enable</returns>
	static bool Tone_Mapping_Enable(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getSwitch();
		}
		else
            throw ICPropertyException("Tone_Mapping_Enable Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Tone_Mapping_Auto is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Tone_Mapping_Auto_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Auto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{b57d3001-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Tone_Mapping_Auto is readonly.
    /// </summary>
    static bool Tone_Mapping_Auto_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Auto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{b57d3001-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Tone_Mapping_Auto Property is not supported by current device.");
    }

	/// <summary>
	/// Set Tone_Mapping_Auto value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Tone_Mapping_Auto(DShowLib::Grabber* pGrabber , bool Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Auto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{b57d3001-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("Tone_Mapping_Auto Property is read only.");
			else
	            pProperty->setSwitch(Value);
		}
		else
            throw ICPropertyException("Tone_Mapping_Auto Property is not supported by current device.");
	}

    /// <summary>
    /// Get Tone_Mapping_Auto value.
    /// </summary>
    /// <returns>Current value of Tone_Mapping_Auto</returns>
	static bool Tone_Mapping_Auto(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Auto : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{b57d3001-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getSwitch();
		}
		else
            throw ICPropertyException("Tone_Mapping_Auto Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Tone_Mapping_Intensity is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Tone_Mapping_Intensity_Abs_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Intensity : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{bd2f432a-02c1-4f32-9aeb-687ca117d2e7}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Tone_Mapping_Intensity is readonly.
    /// </summary>
    static bool Tone_Mapping_Intensity_Abs_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Intensity : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{bd2f432a-02c1-4f32-9aeb-687ca117d2e7}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Tone_Mapping_Intensity Property is not supported by current device.");
    }

	/// <summary>
	/// Set Tone_Mapping_Intensity value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Tone_Mapping_Intensity_Abs(DShowLib::Grabber* pGrabber , double Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Intensity : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{bd2f432a-02c1-4f32-9aeb-687ca117d2e7}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Tone_Mapping_Intensity Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Tone_Mapping_Intensity : Value %f is not in range %f - %f.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Tone_Mapping_Intensity Property is not supported by current device.");
	}

    /// <summary>
    /// Get Tone_Mapping_Intensity value.
    /// </summary>
    /// <returns>Current value of Tone_Mapping_Intensity</returns>
	static double Tone_Mapping_Intensity_Abs(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Intensity : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{bd2f432a-02c1-4f32-9aeb-687ca117d2e7}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Tone_Mapping_Intensity Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Tone_Mapping_Intensity default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_Intensity</returns>
	static double Tone_Mapping_Intensity_Abs_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Intensity : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{bd2f432a-02c1-4f32-9aeb-687ca117d2e7}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Tone_Mapping_Intensity Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_Intensity minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_Intensity</returns>
	static double Tone_Mapping_Intensity_Abs_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Intensity : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{bd2f432a-02c1-4f32-9aeb-687ca117d2e7}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Tone_Mapping_Intensity Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_Intensity maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Tone_Mapping_Intensity</returns>
	static double Tone_Mapping_Intensity_Abs_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Tone_Mapping_Intensity : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{bd2f432a-02c1-4f32-9aeb-687ca117d2e7}"),pProperty);


		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Tone_Mapping_Intensity Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Tone_Mapping_Global_Brightness_Factor is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Tone_Mapping_Global_Brightness_Factor_Abs_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Global_Brightness_Factor : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{d1451fed-c2d8-42ce-910b-2cb566836a77}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Tone_Mapping_Global_Brightness_Factor is readonly.
    /// </summary>
    static bool Tone_Mapping_Global_Brightness_Factor_Abs_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Global_Brightness_Factor : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{d1451fed-c2d8-42ce-910b-2cb566836a77}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.");
    }

	/// <summary>
	/// Set Tone_Mapping_Global_Brightness_Factor value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Tone_Mapping_Global_Brightness_Factor_Abs(DShowLib::Grabber* pGrabber , double Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Global_Brightness_Factor : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{d1451fed-c2d8-42ce-910b-2cb566836a77}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Tone_Mapping_Global_Brightness_Factor Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Tone_Mapping_Global_Brightness_Factor : Value %f is not in range %f - %f.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.");
	}

    /// <summary>
    /// Get Tone_Mapping_Global_Brightness_Factor value.
    /// </summary>
    /// <returns>Current value of Tone_Mapping_Global_Brightness_Factor</returns>
	static double Tone_Mapping_Global_Brightness_Factor_Abs(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Global_Brightness_Factor : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{d1451fed-c2d8-42ce-910b-2cb566836a77}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Tone_Mapping_Global_Brightness_Factor default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_Global_Brightness_Factor</returns>
	static double Tone_Mapping_Global_Brightness_Factor_Abs_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Global_Brightness_Factor : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{d1451fed-c2d8-42ce-910b-2cb566836a77}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_Global_Brightness_Factor minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_Global_Brightness_Factor</returns>
	static double Tone_Mapping_Global_Brightness_Factor_Abs_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_Global_Brightness_Factor : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{d1451fed-c2d8-42ce-910b-2cb566836a77}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_Global_Brightness_Factor maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Tone_Mapping_Global_Brightness_Factor</returns>
	static double Tone_Mapping_Global_Brightness_Factor_Abs_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Tone_Mapping_Global_Brightness_Factor : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{d1451fed-c2d8-42ce-910b-2cb566836a77}"),pProperty);


		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Tone_Mapping_Global_Brightness_Factor Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Tone_Mapping_a is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Tone_Mapping_a_Abs_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_a : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Tone_Mapping_a is readonly.
    /// </summary>
    static bool Tone_Mapping_a_Abs_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_a : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Tone_Mapping_a Property is not supported by current device.");
    }

	/// <summary>
	/// Set Tone_Mapping_a value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Tone_Mapping_a_Abs(DShowLib::Grabber* pGrabber , double Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_a : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Tone_Mapping_a Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Tone_Mapping_a : Value %f is not in range %f - %f.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Tone_Mapping_a Property is not supported by current device.");
	}

    /// <summary>
    /// Get Tone_Mapping_a value.
    /// </summary>
    /// <returns>Current value of Tone_Mapping_a</returns>
	static double Tone_Mapping_a_Abs(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_a : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Tone_Mapping_a Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Tone_Mapping_a default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_a</returns>
	static double Tone_Mapping_a_Abs_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_a : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Tone_Mapping_a Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_a minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_a</returns>
	static double Tone_Mapping_a_Abs_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_a : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Tone_Mapping_a Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_a maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Tone_Mapping_a</returns>
	static double Tone_Mapping_a_Abs_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Tone_Mapping_a : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{48d2d5f5-0bed-4d5a-aa7c-b8a8c41c1179}"),pProperty);


		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Tone_Mapping_a Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Tone_Mapping_b is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Tone_Mapping_b_Abs_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_b : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{8a1a5755-a562-470b-9842-97b08791144c}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Tone_Mapping_b is readonly.
    /// </summary>
    static bool Tone_Mapping_b_Abs_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_b : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{8a1a5755-a562-470b-9842-97b08791144c}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Tone_Mapping_b Property is not supported by current device.");
    }

	/// <summary>
	/// Set Tone_Mapping_b value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Tone_Mapping_b_Abs(DShowLib::Grabber* pGrabber , double Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_b : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{8a1a5755-a562-470b-9842-97b08791144c}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Tone_Mapping_b Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Tone_Mapping_b : Value %f is not in range %f - %f.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Tone_Mapping_b Property is not supported by current device.");
	}

    /// <summary>
    /// Get Tone_Mapping_b value.
    /// </summary>
    /// <returns>Current value of Tone_Mapping_b</returns>
	static double Tone_Mapping_b_Abs(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_b : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{8a1a5755-a562-470b-9842-97b08791144c}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Tone_Mapping_b Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Tone_Mapping_b default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_b</returns>
	static double Tone_Mapping_b_Abs_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_b : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{8a1a5755-a562-470b-9842-97b08791144c}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Tone_Mapping_b Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_b minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_b</returns>
	static double Tone_Mapping_b_Abs_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_b : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{8a1a5755-a562-470b-9842-97b08791144c}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Tone_Mapping_b Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_b maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Tone_Mapping_b</returns>
	static double Tone_Mapping_b_Abs_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Tone_Mapping_b : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{8a1a5755-a562-470b-9842-97b08791144c}"),pProperty);


		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Tone_Mapping_b Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Tone_Mapping_c is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Tone_Mapping_c_Abs_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_c : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{e6d1fed4-c28a-431d-b9ec-0fce3566235a}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Tone_Mapping_c is readonly.
    /// </summary>
    static bool Tone_Mapping_c_Abs_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_c : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{e6d1fed4-c28a-431d-b9ec-0fce3566235a}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Tone_Mapping_c Property is not supported by current device.");
    }

	/// <summary>
	/// Set Tone_Mapping_c value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Tone_Mapping_c_Abs(DShowLib::Grabber* pGrabber , double Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_c : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{e6d1fed4-c28a-431d-b9ec-0fce3566235a}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Tone_Mapping_c Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Tone_Mapping_c : Value %f is not in range %f - %f.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Tone_Mapping_c Property is not supported by current device.");
	}

    /// <summary>
    /// Get Tone_Mapping_c value.
    /// </summary>
    /// <returns>Current value of Tone_Mapping_c</returns>
	static double Tone_Mapping_c_Abs(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_c : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{e6d1fed4-c28a-431d-b9ec-0fce3566235a}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Tone_Mapping_c Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Tone_Mapping_c default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_c</returns>
	static double Tone_Mapping_c_Abs_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_c : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{e6d1fed4-c28a-431d-b9ec-0fce3566235a}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Tone_Mapping_c Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_c minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_c</returns>
	static double Tone_Mapping_c_Abs_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_c : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{e6d1fed4-c28a-431d-b9ec-0fce3566235a}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Tone_Mapping_c Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_c maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Tone_Mapping_c</returns>
	static double Tone_Mapping_c_Abs_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Tone_Mapping_c : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{e6d1fed4-c28a-431d-b9ec-0fce3566235a}"),pProperty);


		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Tone_Mapping_c Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Tone_Mapping_lum_avg is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Tone_Mapping_lum_avg_Abs_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_lum_avg : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{0634aea5-2a19-4292-97bc-7d228ae4c60f}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Tone_Mapping_lum_avg is readonly.
    /// </summary>
    static bool Tone_Mapping_lum_avg_Abs_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_lum_avg : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{0634aea5-2a19-4292-97bc-7d228ae4c60f}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Tone_Mapping_lum_avg Property is not supported by current device.");
    }

	/// <summary>
	/// Set Tone_Mapping_lum_avg value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Tone_Mapping_lum_avg_Abs(DShowLib::Grabber* pGrabber , double Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_lum_avg : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{0634aea5-2a19-4292-97bc-7d228ae4c60f}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Tone_Mapping_lum_avg Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Tone_Mapping_lum_avg : Value %f is not in range %f - %f.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Tone_Mapping_lum_avg Property is not supported by current device.");
	}

    /// <summary>
    /// Get Tone_Mapping_lum_avg value.
    /// </summary>
    /// <returns>Current value of Tone_Mapping_lum_avg</returns>
	static double Tone_Mapping_lum_avg_Abs(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_lum_avg : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{0634aea5-2a19-4292-97bc-7d228ae4c60f}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Tone_Mapping_lum_avg Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Tone_Mapping_lum_avg default value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_lum_avg</returns>
	static double Tone_Mapping_lum_avg_Abs_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_lum_avg : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{0634aea5-2a19-4292-97bc-7d228ae4c60f}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Tone_Mapping_lum_avg Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_lum_avg minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Tone_Mapping_lum_avg</returns>
	static double Tone_Mapping_lum_avg_Abs_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Tone_Mapping_lum_avg : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{0634aea5-2a19-4292-97bc-7d228ae4c60f}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Tone_Mapping_lum_avg Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Tone_Mapping_lum_avg maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Tone_Mapping_lum_avg</returns>
	static double Tone_Mapping_lum_avg_Abs_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Tone_Mapping_lum_avg : No device selected");

		DShowLib::tIVCDAbsoluteValuePropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{3d505ac4-1a28-428b-83e5-85aa8eb441c1}"), DShowLib::StringToGUID(L"{0634aea5-2a19-4292-97bc-7d228ae4c60f}"),pProperty);


		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Tone_Mapping_lum_avg Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Partial_scan_Auto_center is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Partial_scan_Auto_center_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Partial_scan_Auto_center : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{36eaa683-3321-44be-9d73-e1fd4c3fdb87}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Partial_scan_Auto_center is readonly.
    /// </summary>
    static bool Partial_scan_Auto_center_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Partial_scan_Auto_center : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{36eaa683-3321-44be-9d73-e1fd4c3fdb87}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Partial_scan_Auto_center Property is not supported by current device.");
    }

	/// <summary>
	/// Set Partial_scan_Auto_center value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Partial_scan_Auto_center(DShowLib::Grabber* pGrabber , bool Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Partial_scan_Auto_center : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{36eaa683-3321-44be-9d73-e1fd4c3fdb87}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("Partial_scan_Auto_center Property is read only.");
			else
	            pProperty->setSwitch(Value);
		}
		else
            throw ICPropertyException("Partial_scan_Auto_center Property is not supported by current device.");
	}

    /// <summary>
    /// Get Partial_scan_Auto_center value.
    /// </summary>
    /// <returns>Current value of Partial_scan_Auto_center</returns>
	static bool Partial_scan_Auto_center(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Partial_scan_Auto_center : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{36eaa683-3321-44be-9d73-e1fd4c3fdb87}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getSwitch();
		}
		else
            throw ICPropertyException("Partial_scan_Auto_center Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Partial_scan_X_Offset is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Partial_scan_X_Offset_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Partial_scan_X_Offset : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{5e59f654-7b47-4458-b4c6-5d4f0d175fc1}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Partial_scan_X_Offset is readonly.
    /// </summary>
    static bool Partial_scan_X_Offset_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Partial_scan_X_Offset : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{5e59f654-7b47-4458-b4c6-5d4f0d175fc1}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Partial_scan_X_Offset Property is not supported by current device.");
    }

	/// <summary>
	/// Set Partial_scan_X_Offset value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Partial_scan_X_Offset(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Partial_scan_X_Offset : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{5e59f654-7b47-4458-b4c6-5d4f0d175fc1}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Partial_scan_X_Offset Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Partial_scan_X_Offset : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Partial_scan_X_Offset Property is not supported by current device.");
	}

    /// <summary>
    /// Get Partial_scan_X_Offset value.
    /// </summary>
    /// <returns>Current value of Partial_scan_X_Offset</returns>
	static int Partial_scan_X_Offset(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Partial_scan_X_Offset : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{5e59f654-7b47-4458-b4c6-5d4f0d175fc1}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Partial_scan_X_Offset Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Partial_scan_X_Offset defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Partial_scan_X_Offset</returns>
	static int Partial_scan_X_Offset_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Partial_scan_X_Offset : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{5e59f654-7b47-4458-b4c6-5d4f0d175fc1}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Partial_scan_X_Offset Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get Partial_scan_X_Offset minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Partial_scan_X_Offset</returns>
	static int Partial_scan_X_Offset_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Partial_scan_X_Offset : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{5e59f654-7b47-4458-b4c6-5d4f0d175fc1}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Partial_scan_X_Offset Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Partial_scan_X_Offset maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Partial_scan_X_Offset</returns>
	static int Partial_scan_X_Offset_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Partial_scan_X_Offset : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{5e59f654-7b47-4458-b4c6-5d4f0d175fc1}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Partial_scan_X_Offset Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Partial_scan_Y_Offset is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Partial_scan_Y_Offset_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Partial_scan_Y_Offset : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{87fb6c02-98a8-46b0-b18d-6442d9775cd3}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Partial_scan_Y_Offset is readonly.
    /// </summary>
    static bool Partial_scan_Y_Offset_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Partial_scan_Y_Offset : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{87fb6c02-98a8-46b0-b18d-6442d9775cd3}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Partial_scan_Y_Offset Property is not supported by current device.");
    }

	/// <summary>
	/// Set Partial_scan_Y_Offset value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Partial_scan_Y_Offset(DShowLib::Grabber* pGrabber , int Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Partial_scan_Y_Offset : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{87fb6c02-98a8-46b0-b18d-6442d9775cd3}"),pProperty);

		if( pProperty != NULL )
		{
		     if( pProperty->getReadOnly())
                throw ICPropertyException("Partial_scan_Y_Offset Property is read only.");

            if (pProperty->getRangeMin() <= Value && pProperty->getRangeMax() >= Value)
                pProperty->setValue(Value);
            else
			{
				char szError[400];
				sprintf_s(szError,399,"Partial_scan_Y_Offset : Value %d is not in range %d - %d.", Value, pProperty->getRangeMin(), pProperty->getRangeMax() );
                throw ICPropertyException(szError);
			}
		}
		else
            throw ICPropertyException("Partial_scan_Y_Offset Property is not supported by current device.");
	}

    /// <summary>
    /// Get Partial_scan_Y_Offset value.
    /// </summary>
    /// <returns>Current value of Partial_scan_Y_Offset</returns>
	static int Partial_scan_Y_Offset(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Partial_scan_Y_Offset : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{87fb6c02-98a8-46b0-b18d-6442d9775cd3}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getValue();
		}
		else
            throw ICPropertyException("Partial_scan_Y_Offset Property is not supported by current device.");
		
	}

		/// <summary>
    /// Get Partial_scan_Y_Offset defaul value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Partial_scan_Y_Offset</returns>
	static int Partial_scan_Y_Offset_Default(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Partial_scan_Y_Offset : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{87fb6c02-98a8-46b0-b18d-6442d9775cd3}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getDefault();
		}
		else
            throw ICPropertyException("Partial_scan_Y_Offset Property is not supported by current device.");
		
	}


	/// <summary>
    /// Get Partial_scan_Y_Offset minimum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Minimum value of Partial_scan_Y_Offset</returns>
	static int Partial_scan_Y_Offset_Min(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Partial_scan_Y_Offset : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{87fb6c02-98a8-46b0-b18d-6442d9775cd3}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMin();
		}
		else
            throw ICPropertyException("Partial_scan_Y_Offset Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Partial_scan_Y_Offset maximum value.
    /// </summary>
	/// <param name="ic">IC Imaging Control object</param>
    /// <returns>Maximum value of Partial_scan_Y_Offset</returns>
	static int Partial_scan_Y_Offset_Max(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
		throw ICPropertyException("Partial_scan_Y_Offset : No device selected");

		DShowLib::tIVCDRangePropertyPtr pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{2ced6fd6-ab4d-4c74-904c-d682e53b9cc5}"), DShowLib::StringToGUID(L"{87fb6c02-98a8-46b0-b18d-6442d9775cd3}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getRangeMax();
		}
		else
            throw ICPropertyException("Partial_scan_Y_Offset Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Strobe_Enable is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Strobe_Enable_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Strobe_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{dc320ede-df2e-4a90-b926-71417c71c57c}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Strobe_Enable is readonly.
    /// </summary>
    static bool Strobe_Enable_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Strobe_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{dc320ede-df2e-4a90-b926-71417c71c57c}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Strobe_Enable Property is not supported by current device.");
    }

	/// <summary>
	/// Set Strobe_Enable value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Strobe_Enable(DShowLib::Grabber* pGrabber , bool Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Strobe_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{dc320ede-df2e-4a90-b926-71417c71c57c}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("Strobe_Enable Property is read only.");
			else
	            pProperty->setSwitch(Value);
		}
		else
            throw ICPropertyException("Strobe_Enable Property is not supported by current device.");
	}

    /// <summary>
    /// Get Strobe_Enable value.
    /// </summary>
    /// <returns>Current value of Strobe_Enable</returns>
	static bool Strobe_Enable(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Strobe_Enable : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{dc320ede-df2e-4a90-b926-71417c71c57c}"), DShowLib::StringToGUID(L"{b57d3000-0ac6-4819-a609-272a33140aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getSwitch();
		}
		else
            throw ICPropertyException("Strobe_Enable Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Strobe_Mode is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Strobe_Mode_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Strobe_Mode : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{dc320ede-df2e-4a90-b926-71417c71c57c}"), DShowLib::StringToGUID(L"{b41db628-0975-43f8-a9d9-7e0380580acd}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Strobe_Mode is readonly.
    /// </summary>
    static bool Strobe_Mode_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Strobe_Mode : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{dc320ede-df2e-4a90-b926-71417c71c57c}"), DShowLib::StringToGUID(L"{b41db628-0975-43f8-a9d9-7e0380580acd}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Strobe_Mode Property is not supported by current device.");
    }

	/// <summary>
	/// Set Strobe_Mode value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Strobe_Mode(DShowLib::Grabber* pGrabber, std::string Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Strobe_Mode : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{dc320ede-df2e-4a90-b926-71417c71c57c}"), DShowLib::StringToGUID(L"{b41db628-0975-43f8-a9d9-7e0380580acd}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("Strobe_Mode Property is read only.");
			else
			{
				std::string ErrorMessage = "Strobe_Mode : String \""+ Value + "\" is not in the list of available values: \"";
				bool bStringAllowed = false; 
				std::vector<std::string> StringList = pProperty->getStrings();
				for (unsigned int i = 0; i < StringList.size() && !bStringAllowed; i++)
				{
					if (i > 0)
						ErrorMessage += ", ";
					ErrorMessage += StringList[i] + " " ;

					if( Value == StringList[i])
						bStringAllowed = true;
				}
				if (bStringAllowed)
					pProperty->setString(Value);
				else
				{
					ErrorMessage += "\".";
					throw ICPropertyException(ErrorMessage);
				}
			}
		}
		else
            throw ICPropertyException("Strobe_Mode Property is not supported by current device.");
	}

		/// <summary>
	/// Set Strobe_Mode value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Strobe_Mode(DShowLib::Grabber* pGrabber, std::wstring Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Strobe_Mode : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{dc320ede-df2e-4a90-b926-71417c71c57c}"), DShowLib::StringToGUID(L"{b41db628-0975-43f8-a9d9-7e0380580acd}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("Strobe_Mode Property is read only.");
			else
			{
				std::wstring ErrorMessage = L"Strobe_Mode : Tralala String \"" + Value;
				ErrorMessage += L"\" is not in the list of available values: \"";

				bool bStringAllowed = false;
				std::vector<std::wstring> StringList = pProperty->getStringsW();
				for (unsigned int i = 0; i < StringList.size() && !bStringAllowed; i++)
				{
					if (i > 0)
						ErrorMessage += L", ";
					ErrorMessage += StringList[i] + L" ";

					if (Value == StringList[i])
						bStringAllowed = true;
				}
				if (bStringAllowed)
					pProperty->setString(Value);
				else
				{
					ErrorMessage += L"\".";
					std::string s(DShowLib::wstoas(ErrorMessage.c_str()));

					throw ICPropertyException(s);
				}
			}
		}
		else
            throw ICPropertyException("Strobe_Mode Property is not supported by current device.");
	}



    /// <summary>
    /// Get Strobe_Mode value.
    /// </summary>
    /// <returns>Current value of Strobe_Mode</returns>
	static  std::string Strobe_Mode(DShowLib::Grabber* pGrabber)
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Strobe_Mode : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{dc320ede-df2e-4a90-b926-71417c71c57c}"), DShowLib::StringToGUID(L"{b41db628-0975-43f8-a9d9-7e0380580acd}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getString();
		}
		else
            throw ICPropertyException("Strobe_Mode Property is not supported by current device.");
		
	}
    /// <summary>
    /// Get Strobe_Mode value.
    /// </summary>
    /// <returns>Current value of Strobe_Mode</returns>
	static  std::wstring Strobe_ModeW(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Strobe_Mode : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{dc320ede-df2e-4a90-b926-71417c71c57c}"), DShowLib::StringToGUID(L"{b41db628-0975-43f8-a9d9-7e0380580acd}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getStringW();
		}
		else
            throw ICPropertyException("Strobe_Mode Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Strobe_Mode value.
    /// </summary>
    /// <returns>Current value of Strobe_Mode</returns>
	static  std::vector<std::string> Strobe_Mode_GetStrings(DShowLib::Grabber* pGrabber  )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Strobe_Mode : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{dc320ede-df2e-4a90-b926-71417c71c57c}"), DShowLib::StringToGUID(L"{b41db628-0975-43f8-a9d9-7e0380580acd}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getStrings(); //tStringVec(Stringlist);
		}
		else
            throw ICPropertyException("Strobe_Mode Property is not supported by current device.");
		
	}

	/// <summary>
    /// Get Strobe_Mode value.
    /// </summary>
    /// <returns>Current value of Strobe_Mode</returns>
	static  std::vector<std::wstring> Strobe_Mode_GetStringsW(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Strobe_Mode : No device selected");

		DShowLib::tIVCDMapStringsPropertyPtr   pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{dc320ede-df2e-4a90-b926-71417c71c57c}"), DShowLib::StringToGUID(L"{b41db628-0975-43f8-a9d9-7e0380580acd}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getStringsW(); //tStringVecW(Stringlist);
		}
		else
            throw ICPropertyException("Strobe_Mode Property is not supported by current device.");
		
	}
	
	/// <summary>
    /// Check, whether Strobe_Polarity is available for current device.
    /// </summary>
    /// <returns>true : Available, false: not available</returns>
	static bool Strobe_Polarity_Available(DShowLib::Grabber* pGrabber )
	{
		bool bResult = false;
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Strobe_Polarity : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{dc320ede-df2e-4a90-b926-71417c71c57c}"), DShowLib::StringToGUID(L"{b41db628-0975-43f8-a9d9-7e0380580aca}"),pProperty);

		if( pProperty != NULL )
		{
			bResult = true;
		}
	
		return bResult;
	}

	/// <summary>
    /// Returns, whether Strobe_Polarity is readonly.
    /// </summary>
    static bool Strobe_Polarity_Readonly(DShowLib::Grabber* pGrabber )
    {
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Strobe_Polarity : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{dc320ede-df2e-4a90-b926-71417c71c57c}"), DShowLib::StringToGUID(L"{b41db628-0975-43f8-a9d9-7e0380580aca}"),pProperty);

        if (pProperty != NULL)
        {
            return pProperty->getReadOnly();
        }
        else
            throw ICPropertyException(" Strobe_Polarity Property is not supported by current device.");
    }

	/// <summary>
	/// Set Strobe_Polarity value.
	/// </summary>
	/// <param name="Value">Value to set</param>
	static void Strobe_Polarity(DShowLib::Grabber* pGrabber , bool Value )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Strobe_Polarity : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{dc320ede-df2e-4a90-b926-71417c71c57c}"), DShowLib::StringToGUID(L"{b41db628-0975-43f8-a9d9-7e0380580aca}"),pProperty);

		if( pProperty != NULL )
		{
			if( pProperty->getReadOnly())
                throw ICPropertyException("Strobe_Polarity Property is read only.");
			else
	            pProperty->setSwitch(Value);
		}
		else
            throw ICPropertyException("Strobe_Polarity Property is not supported by current device.");
	}

    /// <summary>
    /// Get Strobe_Polarity value.
    /// </summary>
    /// <returns>Current value of Strobe_Polarity</returns>
	static bool Strobe_Polarity(DShowLib::Grabber* pGrabber )
	{
		if( !pGrabber->isDevValid())
			throw ICPropertyException("Strobe_Polarity : No device selected");

		DShowLib::tIVCDSwitchPropertyPtr  pProperty;
		DShowLib::tIVCDPropertyItemsPtr pItems = pGrabber->getAvailableVCDProperties();
		pItems->findInterfacePtr(DShowLib::StringToGUID(L"{dc320ede-df2e-4a90-b926-71417c71c57c}"), DShowLib::StringToGUID(L"{b41db628-0975-43f8-a9d9-7e0380580aca}"),pProperty);

		if( pProperty != NULL )
		{
			return pProperty->getSwitch();
		}
		else
            throw ICPropertyException("Strobe_Polarity Property is not supported by current device.");
		
	}

};

#endif //__ICPROPERTIES__