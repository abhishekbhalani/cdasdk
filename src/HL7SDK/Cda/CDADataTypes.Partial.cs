/******************************************************************************
 * 
 * HL7SDK basic datatypes (partial impl.)
 * 
 *****************************************************************************/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;

namespace HL7SDK.Cda
{
    partial interface Iadxpcity
    {
        Iadxpcity Init(string value);
    }

    partial interface Iadxpcountry
    {
        Iadxpcountry Init(string value);
    }

    partial interface Iadxpcounty
    {
        Iadxpcounty Init(string value);
    }

    partial interface Iadxpdelimiter
    {
        Iadxpdelimiter Init(string value);
    }

    partial interface IadxpdeliveryAddressLine
    {
        IadxpdeliveryAddressLine Init(string value);
    }

    partial interface IadxpdeliveryInstallationArea
    {
        IadxpdeliveryInstallationArea Init(string value);
    }

    partial interface IadxpdeliveryInstallationQualifier
    {
        IadxpdeliveryInstallationQualifier Init(string value);
    }

    partial interface IadxpdeliveryInstallationType
    {
        IadxpdeliveryInstallationType Init(string value);
    }

    partial interface IadxpdeliveryMode
    {
        IadxpdeliveryMode Init(string value);
    }

    partial interface IadxpdeliveryModeIdentifier
    {
        IadxpdeliveryModeIdentifier Init(string value);
    }

    partial interface Iadxpdirection
    {
        Iadxpdirection Init(string value);
    }

    partial interface IadxphouseNumber
    {
        IadxphouseNumber Init(string value);
    }

    partial interface IadxphouseNumberNumeric
    {
        IadxphouseNumberNumeric Init(string value);
    }

    partial interface IadxppostalCode
    {
        IadxppostalCode Init(string value);
    }

    partial interface IadxppostBox
    {
        IadxppostBox Init(string value);
    }

    partial interface Iadxpprecinct
    {
        Iadxpprecinct Init(string value);
    }

    partial interface Iadxpstate
    {
        Iadxpstate Init(string value);
    }

    partial interface IadxpstreetAddressLine
    {
        IadxpstreetAddressLine Init(string value);
    }

    partial interface IadxpstreetName
    {
        IadxpstreetName Init(string value);
    }

    partial interface IadxpstreetNameBase
    {
        IadxpstreetNameBase Init(string value);
    }

    partial interface IadxpstreetNameType
    {
        IadxpstreetNameType Init(string value);
    }

    partial interface IadxpunitID
    {
        IadxpunitID Init(string value);
    }

    partial interface IadxpunitType
    {
        IadxpunitType Init(string value);
    }

    partial interface IAssignedAuthor
    {
    }

    partial interface IBL
    {
        /// <summary>
        /// Initializes an instance of BL object using the specified boolean value
        /// </summary>
        IBL Init(bool value);
    }

    partial interface IBXIT_CD
    {
        int Qty
        {
            get;
            set;
        }
    }

    partial interface IBXIT_IVL_PQ
    {
        new IPQ Center
        {
            get;
        }

        new IIVXB_PQ High
        {
            get;
        }

        new IIVXB_PQ Low
        {
            get;
        }

        int Qty
        {
            get;
            set;
        }

        new IPQ Width
        {
            get;
        }

        new IIVL_PQ Init(double Value = 0, IIVXB_PQ low = null, IIVXB_PQ high = null, IPQ width = null, IPQ center = null);

        new void Reset();
    }

    partial interface ICD
    {
        /// <summary>
        /// Initializes an instance of CD object using the specified code, codeSystem, codeSystemName and displayName. All the arguments are optional.
        /// </summary>
        ICD Init([Optional] Object code, [Optional] Object codeSystem, [Optional] Object codeSystemName, [Optional] Object displayName);
    }

    partial interface IED
    {
        byte[] IntegrityCheck
        {
            get;
            set;
        }
    }

    partial interface Iendelimiter
    {
        Iendelimiter Init(string value);
    }

    partial interface Ienfamily
    {
        Ienfamily Init(string value);
    }

    partial interface Iengiven
    {
        Iengiven Init(string value);
    }

    partial interface Ienprefix
    {
        Ienprefix Init(string value);
    }

    partial interface Iensuffix
    {
        Iensuffix Init(string value);
    }

    partial interface IHXIT_PQ
    {
        new double Value
        {
            get;
            set;
        }
    }

    partial interface III
    {
        /// <summary>
        /// Initializes an instance of II object using the specified root, extension and assigningAuthorityName values. All the arguments are optional.
        /// </summary>
        III Init([Optional] Object root, [Optional] Object extension, [Optional] Object assigningAuthorityName);
    }

    partial interface IIICollection
    {
        [DispId(11)]
        string Find(string root);
    }

    partial interface IINT
    {
        int Value
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes an instance of IINT object using the specified integer value.
        /// </summary>

        IINT Init(int value);
    }

    partial interface IIVL_INT
    {
        IINT Center { get; }

        IIVXB_INT High { get; }

        IIVXB_INT Low { get; }

        new int Value
        {
            get;
            set;
        }
        
        IINT Width { get; }
        
        IIVL_INT Init(int Value = 0, IIVXB_INT low = null, IIVXB_INT high = null, IINT width = null, IINT center = null);

        void Reset();
    }

    partial interface IIVL_MO
    {
        IMO Center { get; }

        IIVXB_MO High { get; }

        IIVXB_MO Low { get; }

        IMO Width { get; }

        IIVL_MO Init(Decimal Value = 0, IIVXB_MO low = null, IIVXB_MO high = null, IMO width = null, IMO center = null);
        void Reset();
    }

    partial interface IIVL_PPD_PQ
    {
        IPPD_PQ Center
        {
            get;
        }

        IIVXB_PPD_PQ High
        {
            get;
        }

        IIVXB_PPD_PQ Low
        {
            get;
        }

        new double Value
        {
            get;
            set;
        }
        IPPD_PQ Width
        {
            get;
        }
        IIVL_PPD_PQ Init(double Value = 0, IIVXB_PPD_PQ low = null, IIVXB_PPD_PQ high = null, IPPD_PQ width = null, IPPD_PQ center = null);

        void Reset();
    }

    partial interface IIVL_PPD_TS
    {
        IPPD_TS Center
        {
            get;
        }

        IIVXB_PPD_TS High
        {
            get;
        }

        IIVXB_PPD_TS Low
        {
            get;
        }
        IPPD_PQ Width
        {
            get;
        }
        IIVL_PPD_TS Init(string Value = null, IIVXB_PPD_TS low = null, IIVXB_PPD_TS high = null, IPPD_PQ width = null, IPPD_TS center = null);
        void Reset();
    }

    partial interface IIVL_PQ
    {
        IPQ Center
        {
            get;
        }

        IIVXB_PQ High
        {
            get;
        }

        IIVXB_PQ Low
        {
            get;
        }

        new double Value
        {
            get;
            set;
        }

        IPQ Width
        {
            get;
        }

        IIVL_PQ Init(double Value = 0, IIVXB_PQ low = null, IIVXB_PQ high = null, IPQ width = null, IPQ center = null);

        void Reset();
    }
    partial interface IIVL_REAL
    {
        IREAL Center
        {
            get;
        }

        IIVXB_REAL High
        {
            get;
        }

        IIVXB_REAL Low
        {
            get;
        }
        IREAL Width
        {
            get;
        }
        IIVL_REAL Init(double Value = 0, IIVXB_REAL low = null, IIVXB_REAL high = null, IREAL width = null, IREAL center = null);

        void Reset();
    }

    partial interface IIVL_TS
    {
        ITS Center
        {
            get;
        }

        IIVXB_TS High
        {
            get;
        }

        IIVXB_TS Low
        {
            get;
        }

        IPQ Width
        {
            get;
        }

        IIVL_TS Init(String Value = null, IIVXB_TS low = null, IIVXB_TS high = null, IPQ width = null, ITS center = null);
        void Reset();
    }

    partial interface IIVXB_INT
    {
        new int Value
        {
            get;
            set;
        }
    }

    partial interface IIVXB_MO
    {
        new decimal Value
        {
            get;
            set;
        }
    }

    partial interface IIVXB_PPD_PQ
    {
        new double Value
        {
            get;
            set;
        }
    }


    partial interface IIVXB_PPD_TS
    {
        new DateTime AsDateTime
        {
            get;
            set;
        }

        new bool DateTimeSpecified
        {
            get;
        }
    }

    partial interface IIVXB_PQ
    {
        new double Value
        {
            get;
            set;
        }
    }

    partial interface IIVXB_REAL
    {
        new double Value
        {
            get;
            set;
        }
    }

    partial interface IIVXB_TS
    {
        new DateTime AsDateTime
        {
            get;
            set;
        }

        new bool DateTimeSpecified
        {
            get;
        }
    }

    partial interface IMO
    {
        decimal Value
        {
            get;
        }

        /// <summary>
        /// Initializes an instance of IMO object using the specified decimal value.
        /// </summary>
        IMO Init(decimal value);
    }

    partial interface IPN
    {
        string FindENFamily();
        string FindENGiven();
        string FindENSuffix();
    }

    partial interface IPPD_PQ
    {
        new double Value
        {
            get;
            set;
        }
    }

    partial interface IPPD_TS
    {
        new DateTime AsDateTime
        {
            get;
            set;
        }

        new bool DateTimeSpecified
        {
            get;
        }
    }

    partial interface IPQ
    {
        double Value
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes an instance of IMO object using the specified double value.
        /// </summary>
        IPQ Init(double value);
    }

    partial interface IREAL
    {
        double Value
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes an instance of IMO object using the specified double value.
        /// </summary>
        IREAL Init(double value);
    }

    partial interface ISXCM_INT
    {
        new int Value
        {
            get;
            set;
        }
    }

    partial interface ISXCM_MO
    {
        new decimal Value
        {
            get;
            set;
        }
    }

    partial interface ISXCM_PPD_PQ
    {
        new double Value
        {
            get;
            set;
        }
    }

    partial interface ISXCM_PPD_TS
    {
        new DateTime AsDateTime
        {
            get;
            set;
        }

        new bool DateTimeSpecified
        {
            get;
        }
    }

    partial interface ISXCM_PQ
    {
        new double Value
        {
            get;
            set;
        }
    }

    partial interface ISXCM_REAL
    {
        new double Value
        {
            get;
            set;
        }
    }

    partial interface ISXCM_TS
    {
        new DateTime AsDateTime
        {
            get;
            set;
        }

        new bool DateTimeSpecified
        {
            get;
        }
    }

    partial interface ITS
    {
        /// <summary>
        /// Converts the specified string representation of a date and time of TS object to an equivalent date and time value.
        /// </summary>
        DateTime AsDateTime
        {
            get;
            set;
        }

        /// <summary>
        /// Gets a value indicating whether the Value property of TS object contains valid DateTime
        /// </summary>
        bool DateTimeSpecified
        {
            get;
        }

        /// <summary>
        /// Initializes an instance of TS object to a specified DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        ITS Init(DateTime value);
    }

    internal static class IVLUtil
    {
        // Acceptable combinations of IVL parts 
        public static bool[,] PP = 
        {
            /* low:high:width:center */
            {true,  false, false, false},
            {true,  true,  false, false},
            {true,  false, true,  false},

            {false, true,  false, false},

            {false, false, true,  false},
            {false, true,  true,  false},

            {false, false, false, true},
            {false, false, true,  true},
        };

        public static IT GetPart<IT, TItemType, TPOCD>(CDAObject owner, string partName, TItemType[] names, TPOCD[] values)
            where IT : class
            where TPOCD : class
        {
            List<TItemType> listNames = new List<TItemType>(names == null ? new TItemType[0] : names);
            List<TPOCD> listValues = new List<TPOCD>(values == null ? new TPOCD[0] : values);

            System.Diagnostics.Debug.Assert(listNames.Count == listValues.Count);

            int index = listNames.IndexOf((TItemType)Enum.Parse(typeof(TItemType), partName));
            if (index == -1)
                return null;

            return ElementFactory.Wrap(listValues[index], owner) as IT;
        }

        public static Object InitIvl<TValueType, TItemChoiceType, TPOCDItemType, TLow, ILow, THigh, IHigh, TWidth, IWidth, TCenter, ICenter>
        (
            Object Self,
            Func<TItemChoiceType[]> GetItemsChoiceType,
            Action<TItemChoiceType[]> SetItemsChoiseType,
            Func<TPOCDItemType[]> GetItems,
            Action<TPOCDItemType[]> SetItems,
            Func<TValueType> GetValue,
            Action<TValueType> SetValue,
            TValueType Value,
            ref ILow low,
            ref IHigh high,
            ref IWidth width,
            ref ICenter center
        )
            where TPOCDItemType : class
            where TLow : CDAObject, ILow
            where THigh : CDAObject, IHigh
            where TWidth : CDAObject, IWidth
            where TCenter : CDAObject, ICenter
        {
            List<TItemChoiceType> names = new List<TItemChoiceType>(GetItemsChoiceType() == null ? new TItemChoiceType[0] : GetItemsChoiceType());
            List<TPOCDItemType> items = new List<TPOCDItemType>(GetItems() == null ? new TPOCDItemType[0] : GetItems());

            if (low == null && high == null && width == null && center == null)
            {
                SetItemsChoiseType(names.ToArray());
                SetItems(items.ToArray());
                SetValue((TValueType)Value);
                return Self;
            }

            if (low != null && !(low is TLow))
                throw new InvalidCastException("Invalid argument. The Low argument is not an instance of " + typeof(TLow).Name);
            if (high != null && !(high is THigh))
                throw new InvalidCastException("Invalid argument. The High argument is not an instance of " + typeof(THigh).Name);
            if (width != null && !(width is TWidth))
                throw new InvalidCastException("Invalid argument. The Width argument is not an instance of " + typeof(TWidth).Name);
            if (center != null && !(center is TCenter))
                throw new InvalidCastException("Invalid argument. The Center argument is not an instance of " + typeof(TCenter));

            TLow pLow = low as TLow;
            THigh pHigh = high as THigh;
            TWidth pWidth = width as TWidth;
            TCenter pCenter = center as TCenter;

            // center = 0, high = 1, low = 2, width = 3
            for (int i = 0; i < 8; i++)
            {
                if (IVLUtil.PP[i, 0] == (pLow != null) &&
                    IVLUtil.PP[i, 1] == (pHigh != null) &&
                    IVLUtil.PP[i, 2] == (pWidth != null) &&
                    IVLUtil.PP[i, 3] == (pCenter != null))
                {
                    if (pLow != null)
                    {
                        items.Add(pLow.element as TPOCDItemType);
                        names.Add((TItemChoiceType)Enum.Parse(typeof(TItemChoiceType), "low"));
                    }
                    if (pHigh != null)
                    {
                        items.Add(pHigh.element as TPOCDItemType);
                        names.Add((TItemChoiceType)Enum.Parse(typeof(TItemChoiceType), "high"));
                    }
                    if (pWidth != null)
                    {
                        items.Add(pWidth.element as TPOCDItemType);
                        names.Add((TItemChoiceType)Enum.Parse(typeof(TItemChoiceType), "width"));
                    }
                    if (pCenter != null)
                    {
                        items.Add(pCenter.element as TPOCDItemType);
                        names.Add((TItemChoiceType)Enum.Parse(typeof(TItemChoiceType), "center"));
                    }
                    SetItems(items.ToArray());
                    SetItemsChoiseType(names.ToArray());
                    return Self;
                }
            }

            throw new ArgumentException("Cannot intialize " + Self.GetType().Name + " with provided values. Invalid values combination of interval data type.");
        }
    }

    partial class adxpcity
    {
        /// <summary>
        /// Initializes an instance of adxpcity object using the specified value
        /// </summary>
        public Iadxpcity Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpcountry
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public Iadxpcountry Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpcounty
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public Iadxpcounty Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpdelimiter
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public Iadxpdelimiter Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpdeliveryAddressLine
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public IadxpdeliveryAddressLine Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpdeliveryInstallationArea
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public IadxpdeliveryInstallationArea Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpdeliveryInstallationQualifier
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public IadxpdeliveryInstallationQualifier Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpdeliveryInstallationType
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public IadxpdeliveryInstallationType Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpdeliveryMode
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public IadxpdeliveryMode Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpdeliveryModeIdentifier
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public IadxpdeliveryModeIdentifier Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpdirection
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public Iadxpdirection Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxphouseNumber
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public IadxphouseNumber Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxphouseNumberNumeric
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public IadxphouseNumberNumeric Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxppostalCode
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public IadxppostalCode Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxppostBox
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public IadxppostBox Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpprecinct
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public Iadxpprecinct Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpstate
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public Iadxpstate Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpstreetAddressLine
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public IadxpstreetAddressLine Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpstreetName
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public IadxpstreetName Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpstreetNameBase
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public IadxpstreetNameBase Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpstreetNameType
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public IadxpstreetNameType Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpunitID
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public IadxpunitID Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class adxpunitType
    {
        /// <summary>
        /// Initializes an instance of object using the specified address part value
        /// </summary>
        public IadxpunitType Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class BL
    {
        public IBL Init(bool value)
        {
            this.Value = value;
            return this;
        }
    }

    partial class BXIT_CD
    {
        public int Qty
        {
            get
            {
                return Convert.ToInt32(Element.qty);
            }
            set
            {
                Element.qty = Convert.ToString(value);
            }
        }
    }

    partial class BXIT_IVL_PQ
    {
        public int Qty
        {
            get
            {
                int result = 0;
                if (!int.TryParse(Element.qty, out result))
                    return 0;
                return result;
            }
            set
            {
                Element.qty = Convert.ToString(value, Util.DEFAULT_CULTURE_INFO);
            }
        }
    }

    partial class CD
    {
        public ICD Init([Optional] Object code, [Optional] Object codeSystem, [Optional] Object codeSystemName, [Optional] Object displayName)
        {
            if (code is String && !String.IsNullOrWhiteSpace("" + code))
                this.Code = "" + code;
            if (codeSystem is String && !String.IsNullOrWhiteSpace("" + codeSystem))
                this.CodeSystem = "" + codeSystem;
            if (codeSystemName is String && !String.IsNullOrWhiteSpace("" + codeSystemName))
                this.CodeSystemName = "" + codeSystemName;
            if (displayName is String && !String.IsNullOrWhiteSpace("" + displayName))
                this.DisplayName = "" + displayName;
            return this;
        }
    }

    partial class ED
    {
        /// <summary>
        /// Specifies that the digital signature
        /// </summary>
        public byte[] IntegrityCheck
        {
            get
            {
                if (Element.integrityCheck == null)
                    return new byte[0];
                return Element.integrityCheck;
            }
            set
            {
                if (value == null)
                    Element.integrityCheck = new byte[0];
                Element.integrityCheck = value;
            }
        }
    }

    partial class endelimiter
    {
        public Iendelimiter Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class enfamily
    {
        public Ienfamily Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class engiven
    {
        public Iengiven Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class enprefix
    {
        public Ienprefix Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class ensuffix
    {
        public Iensuffix Init(string value)
        {
            this.Text = value;
            return this;
        }
    }

    partial class ENXP
    {
        public new String Text
        {
            get
            {
                if (Element.Text == null)
                    return String.Empty;
                return String.Join("", Element.Text);
            }
            set
            {
                Element.Text = new[] { value };
            }
        }
    }

    partial class GLIST_PQ
    {
        public int Denominator
        {
            get
            {
                int result = 0;
                if (!int.TryParse(Element.denominator, out result))
                    return 0;
                return result;
            }
            set
            {
                Element.denominator = Convert.ToString(value);
            }
        }

        public int Period
        {
            get
            {
                int result = 0;
                if (!int.TryParse(Element.period, out result))
                    return 0;
                return result;
            }
            set
            {
                Element.period = Convert.ToString(value);
            }
        }
    }

    partial class GLIST_TS
    {
        public int Denominator
        {
            get
            {
                int result = 0;
                if (!int.TryParse(Element.denominator, out result))
                    return 0;
                return result;
            }
            set
            {
                Element.denominator = Convert.ToString(value);
            }
        }

        public int Period
        {
            get
            {
                int result = 0;
                if (!int.TryParse(Element.period, out result))
                    return 0;
                return result;
            }
            set
            {
                Element.period = Convert.ToString(value);
            }
        }
    }

    partial class II
    {
        public III Init([Optional] Object root, [Optional] Object extension, [Optional] Object assigningAuthorityName)
        {
            if (root is String)
                this.Root = Convert.ToString(root);
            if (extension is String)
                this.Extension = Convert.ToString(extension);
            if (assigningAuthorityName is String)
                this.AssigningAuthorityName = Convert.ToString(assigningAuthorityName);
            return this;
        }
    }

    partial class IICollection
    {
        public string Find(string root)
        {
            foreach (II ii in this)
            {
                if (ii.Root == root)
                    return ii.Extension;
            }
            return String.Empty;
        }
    }

    partial class INT
    {
        public int Value
        {
            get
            {
                int result = 0;
                if (int.TryParse(Element.value, out result))
                    return result;
                return 0;
            }
            set
            {
                Element.value = Convert.ToString(value);
            }
        }

        public IINT Init(int value)
        {
            this.Value = value;
            return this;
        }
    }

    partial class IVL_INT : IIVL_INT
    {
        public IINT Center
        {
            get
            {
                return IVLUtil.GetPart<IINT, HL7SDK.Xml.Cda.ItemsChoiceType4, HL7SDK.Xml.Cda.INT>(this, "center", Element.ItemsElementName, Element.Items) as IINT;
            }
        }

        public IIVXB_INT High
        {
            get
            {
                return IVLUtil.GetPart<IIVXB_INT, HL7SDK.Xml.Cda.ItemsChoiceType4, HL7SDK.Xml.Cda.INT>(this, "high", Element.ItemsElementName, Element.Items);
            }
        }

        public IIVXB_INT Low
        {
            get
            {
                return IVLUtil.GetPart<IIVXB_INT, HL7SDK.Xml.Cda.ItemsChoiceType4, HL7SDK.Xml.Cda.INT>(this, "low", Element.ItemsElementName, Element.Items);
            }
        }
        public IINT Width
        {
            get
            {
                return IVLUtil.GetPart<IINT, HL7SDK.Xml.Cda.ItemsChoiceType4, HL7SDK.Xml.Cda.INT>(this, "width", Element.ItemsElementName, Element.Items) as IINT;
            }
        }
        public IIVL_INT Init(int Value = 0, IIVXB_INT low = null, IIVXB_INT high = null, IINT width = null, IINT center = null)
        {
            return IVLUtil.InitIvl<int, HL7SDK.Xml.Cda.ItemsChoiceType4, HL7SDK.Xml.Cda.INT, IVXB_INT, IIVXB_INT, IVXB_INT, IIVXB_INT, INT, IINT, INT, IINT>(
                this,
                () => { return Element.ItemsElementName; },
                (x) => { Element.ItemsElementName = x; },
                () => { return Element.Items; },
                (x1) => { Element.Items = x1; },
                () => { return this.Value; },
                (x2) => { this.Value = x2; },
                Value,
                ref low,
                ref high,
                ref width,
                ref center) as IIVL_INT;
        }

        public void Reset()
        {
            Element.Items = new Xml.Cda.INT[0];
            Element.ItemsElementName = new Xml.Cda.ItemsChoiceType4[0];
        }
    }

    partial class IVL_MO
    {
        public IMO Center
        {
            get
            {
                return IVLUtil.GetPart<IMO, HL7SDK.Xml.Cda.ItemsChoiceType6, HL7SDK.Xml.Cda.MO>(this, "center", Element.ItemsElementName, Element.Items);
            }
        }

        public IIVXB_MO High
        {
            get
            {
                return IVLUtil.GetPart<IIVXB_MO, HL7SDK.Xml.Cda.ItemsChoiceType6, HL7SDK.Xml.Cda.MO>(this, "high", Element.ItemsElementName, Element.Items);
            }
        }

        public IIVXB_MO Low
        {
            get
            {
                return IVLUtil.GetPart<IIVXB_MO, HL7SDK.Xml.Cda.ItemsChoiceType6, HL7SDK.Xml.Cda.MO>(this, "low", Element.ItemsElementName, Element.Items);
            }
        }
        public IMO Width
        {
            get
            {
                return IVLUtil.GetPart<IMO, HL7SDK.Xml.Cda.ItemsChoiceType6, HL7SDK.Xml.Cda.MO>(this, "width", Element.ItemsElementName, Element.Items);
            }
        }
        public IIVL_MO Init(Decimal Value = 0, IIVXB_MO low = null, IIVXB_MO high = null, IMO width = null, IMO center = null)
        {
            return IVLUtil.InitIvl<decimal, HL7SDK.Xml.Cda.ItemsChoiceType6, HL7SDK.Xml.Cda.MO, IVXB_MO, IIVXB_MO, IVXB_MO, IIVXB_MO, MO, IMO, MO, IMO>(
                this,
                () => { return Element.ItemsElementName; },
                (x) => { Element.ItemsElementName = x; },
                () => { return Element.Items; },
                (x1) => { Element.Items = x1; },
                () => { return this.Value; },
                (x2) => { this.Value = x2; },
                Value,
                ref low,
                ref high,
                ref width,
                ref center) as IIVL_MO;
        }

        public void Reset()
        {
            Element.Items = new Xml.Cda.MO[0];
            Element.ItemsElementName = new Xml.Cda.ItemsChoiceType6[0];
        }
    }

    partial class IVL_PPD_PQ : IIVL_PPD_PQ
    {
        public IPPD_PQ Center
        {
            get
            {
                return IVLUtil.GetPart<IPPD_PQ, HL7SDK.Xml.Cda.ItemsChoiceType1, HL7SDK.Xml.Cda.PPD_PQ>(this, "center", Element.ItemsElementName, Element.Items);
            }
        }

        public IIVXB_PPD_PQ High
        {
            get
            {
                return IVLUtil.GetPart<IIVXB_PPD_PQ, HL7SDK.Xml.Cda.ItemsChoiceType1, HL7SDK.Xml.Cda.PPD_PQ>(this, "high", Element.ItemsElementName, Element.Items);
            }
        }

        public IIVXB_PPD_PQ Low
        {
            get
            {
                return IVLUtil.GetPart<IIVXB_PPD_PQ, HL7SDK.Xml.Cda.ItemsChoiceType1, HL7SDK.Xml.Cda.PPD_PQ>(this, "low", Element.ItemsElementName, Element.Items);
            }
        }
        public IPPD_PQ Width
        {
            get
            {
                return IVLUtil.GetPart<IPPD_PQ, HL7SDK.Xml.Cda.ItemsChoiceType1, HL7SDK.Xml.Cda.PPD_PQ>(this, "width", Element.ItemsElementName, Element.Items);
            }
        }
        public IIVL_PPD_PQ Init(double Value = 0, IIVXB_PPD_PQ low = null, IIVXB_PPD_PQ high = null, IPPD_PQ width = null, IPPD_PQ center = null)
        {
            return IVLUtil.InitIvl<double, HL7SDK.Xml.Cda.ItemsChoiceType1, HL7SDK.Xml.Cda.PPD_PQ, IVXB_PPD_PQ, IIVXB_PPD_PQ, IVXB_PPD_PQ, IIVXB_PPD_PQ, PPD_PQ, IPPD_PQ, PPD_PQ, IPPD_PQ>(
                this,
                () => { return Element.ItemsElementName; },
                (x) => { Element.ItemsElementName = x; },
                () => { return Element.Items; },
                (x1) => { Element.Items = x1; },
                () => { return this.Value; },
                (x2) => { this.Value = x2; },
                Value,
                ref low,
                ref high,
                ref width,
                ref center) as IIVL_PPD_PQ;
        }

        public void Reset()
        {
            Element.Items = new Xml.Cda.PPD_PQ[0];
            Element.ItemsElementName = new Xml.Cda.ItemsChoiceType1[0];
        }
    }

    partial class IVL_PPD_TS
    {
        public IPPD_TS Center
        {
            get
            {
                return IVLUtil.GetPart<IPPD_TS, HL7SDK.Xml.Cda.ItemsChoiceType3, HL7SDK.Xml.Cda.QTY>(this, "center", Element.ItemsElementName, Element.Items);
            }
        }

        public IIVXB_PPD_TS High
        {
            get
            {
                return IVLUtil.GetPart<IIVXB_PPD_TS, HL7SDK.Xml.Cda.ItemsChoiceType3, HL7SDK.Xml.Cda.QTY>(this, "high", Element.ItemsElementName, Element.Items);
            }
        }

        public IIVXB_PPD_TS Low
        {
            get
            {
                return IVLUtil.GetPart<IIVXB_PPD_TS, HL7SDK.Xml.Cda.ItemsChoiceType3, HL7SDK.Xml.Cda.QTY>(this, "low", Element.ItemsElementName, Element.Items);
            }
        }
        public IPPD_PQ Width
        {
            get
            {
                return IVLUtil.GetPart<IPPD_PQ, HL7SDK.Xml.Cda.ItemsChoiceType3, HL7SDK.Xml.Cda.QTY>(this, "width", Element.ItemsElementName, Element.Items);
            }
        }
        public IIVL_PPD_TS Init(string Value = null, IIVXB_PPD_TS low = null, IIVXB_PPD_TS high = null, IPPD_PQ width = null, IPPD_TS center = null)
        {
            return IVLUtil.InitIvl<string, HL7SDK.Xml.Cda.ItemsChoiceType3, HL7SDK.Xml.Cda.QTY,
                   IVXB_PPD_TS, IIVXB_PPD_TS,
                   IVXB_PPD_TS, IIVXB_PPD_TS,
                   PPD_PQ, IPPD_PQ,
                   PPD_TS, IPPD_TS>(
                this,
                () => { return Element.ItemsElementName; },
                (x) => { Element.ItemsElementName = x; },
                () => { return Element.Items; },
                (x1) => { Element.Items = x1; },
                () => { return this.Value; },
                (x2) => { this.Value = x2; },
                Value,
                ref low,
                ref high,
                ref width,
                ref center) as IIVL_PPD_TS;
        }

        public void Reset()
        {
            Element.Items = new Xml.Cda.PPD_PQ[0];
            Element.ItemsElementName = new Xml.Cda.ItemsChoiceType3[0];
        }
    }

    partial class IVL_PQ
    {
        public IPQ Center
        {
            get
            {
                return IVLUtil.GetPart<IPQ, HL7SDK.Xml.Cda.ItemsChoiceType, HL7SDK.Xml.Cda.PQ>(this, "center", Element.ItemsElementName, Element.Items);
            }
        }

        public IIVXB_PQ High
        {
            get
            {
                return IVLUtil.GetPart<IIVXB_PQ, HL7SDK.Xml.Cda.ItemsChoiceType, HL7SDK.Xml.Cda.PQ>(this, "high", Element.ItemsElementName, Element.Items);
            }
        }

        public IIVXB_PQ Low
        {
            get
            {
                return IVLUtil.GetPart<IIVXB_PQ, HL7SDK.Xml.Cda.ItemsChoiceType, HL7SDK.Xml.Cda.PQ>(this, "low", Element.ItemsElementName, Element.Items);
            }
        }

        public IPQ Width
        {
            get
            {
                return IVLUtil.GetPart<IPQ, HL7SDK.Xml.Cda.ItemsChoiceType, HL7SDK.Xml.Cda.PQ>(this, "width", Element.ItemsElementName, Element.Items);
            }
        }

        /// <summary>
        /// Initializes an instance of IVL_PQ class
        /// </summary>
        public IIVL_PQ Init(double Value = 0, IIVXB_PQ low = null, IIVXB_PQ high = null, IPQ width = null, IPQ center = null)
        {
            return IVLUtil.InitIvl<double, HL7SDK.Xml.Cda.ItemsChoiceType, HL7SDK.Xml.Cda.PQ, IVXB_PQ, IIVXB_PQ, IVXB_PQ, IIVXB_PQ, PQ, IPQ, PQ, IPQ>(
                this,
                () => { return Element.ItemsElementName; },
                (x) => { Element.ItemsElementName = x; },
                () => { return Element.Items; },
                (x1) => { Element.Items = x1; },
                () => { return this.Value; },
                (x2) => { this.Value = x2; },
                Value,
                ref low,
                ref high,
                ref width,
                ref center) as IIVL_PQ;
        }

        public void Reset()
        {
            Element.Items = new Xml.Cda.PQ[0];
            Element.ItemsElementName = new Xml.Cda.ItemsChoiceType[0];
        }
    }

    partial class IVL_REAL
    {
        public IREAL Center
        {
            get
            {
                return IVLUtil.GetPart<IREAL, HL7SDK.Xml.Cda.ItemsChoiceType5, HL7SDK.Xml.Cda.REAL>(this, "center", Element.ItemsElementName, Element.Items);
            }
        }

        public IIVXB_REAL High
        {
            get
            {
                return IVLUtil.GetPart<IIVXB_REAL, HL7SDK.Xml.Cda.ItemsChoiceType5, HL7SDK.Xml.Cda.REAL>(this, "high", Element.ItemsElementName, Element.Items);
            }
        }

        public IIVXB_REAL Low
        {
            get
            {
                return IVLUtil.GetPart<IIVXB_REAL, HL7SDK.Xml.Cda.ItemsChoiceType5, HL7SDK.Xml.Cda.REAL>(this, "low", Element.ItemsElementName, Element.Items);
            }
        }

        public IREAL Width
        {
            get
            {
                return IVLUtil.GetPart<IREAL, HL7SDK.Xml.Cda.ItemsChoiceType5, HL7SDK.Xml.Cda.REAL>(this, "width", Element.ItemsElementName, Element.Items);
            }
        }

        public IIVL_REAL Init(double Value = 0, IIVXB_REAL low = null, IIVXB_REAL high = null, IREAL width = null, IREAL center = null)
        {
            return IVLUtil.InitIvl<double, HL7SDK.Xml.Cda.ItemsChoiceType5, HL7SDK.Xml.Cda.REAL, IVXB_REAL, IIVXB_REAL, IVXB_REAL, IIVXB_REAL, REAL, IREAL, REAL, IREAL>(
                this,
                () => { return Element.ItemsElementName; },
                (x) => { Element.ItemsElementName = x; },
                () => { return Element.Items; },
                (x1) => { Element.Items = x1; },
                () => { return this.Value; },
                (x2) => { this.Value = x2; },
                Value,
                ref low,
                ref high,
                ref width,
                ref center) as IIVL_REAL;
        }

        public void Reset()
        {
            Element.Items = new Xml.Cda.REAL[0];
            Element.ItemsElementName = new Xml.Cda.ItemsChoiceType5[0];
        }
    }

    partial class IVL_TS : IIVL_TS
    {
        public ITS Center
        {
            get
            {
                return IVLUtil.GetPart<ITS, HL7SDK.Xml.Cda.ItemsChoiceType2, HL7SDK.Xml.Cda.QTY>(this, "center", Element.ItemsElementName, Element.Items);
            }
        }

        public IIVXB_TS High
        {
            get
            {
                return IVLUtil.GetPart<IIVXB_TS, HL7SDK.Xml.Cda.ItemsChoiceType2, HL7SDK.Xml.Cda.QTY>(this, "high", Element.ItemsElementName, Element.Items);
            }
        }

        public IIVXB_TS Low
        {
            get
            {
                return IVLUtil.GetPart<IIVXB_TS, HL7SDK.Xml.Cda.ItemsChoiceType2, HL7SDK.Xml.Cda.QTY>(this, "low", Element.ItemsElementName, Element.Items);
            }
        }

        public IPQ Width
        {
            get
            {
                return IVLUtil.GetPart<IPQ, HL7SDK.Xml.Cda.ItemsChoiceType2, HL7SDK.Xml.Cda.QTY>(this, "width", Element.ItemsElementName, Element.Items);
            }
        }

        public IIVL_TS Init(String Value = null, IIVXB_TS low = null, IIVXB_TS high = null, IPQ width = null, ITS center = null)
        {
            return IVLUtil.InitIvl<string, HL7SDK.Xml.Cda.ItemsChoiceType2, HL7SDK.Xml.Cda.QTY, IVXB_TS, IIVXB_TS, IVXB_TS, IIVXB_TS, PQ, IPQ, TS, ITS>(
                this,
                () => { return Element.ItemsElementName; },
                (x) => { Element.ItemsElementName = x; },
                () => { return Element.Items; },
                (x1) => { Element.Items = x1; },
                () => { return Element.value; },
                (x2) => { Element.value = x2; },
                Value,
                ref low,
                ref high,
                ref width,
                ref center) as IIVL_TS;
        }

        public void Reset()
        {
            Element.Items = new Xml.Cda.QTY[0];
            Element.ItemsElementName = new Xml.Cda.ItemsChoiceType2[0];
        }
    }

    partial class IVXB_INT
    {
        public new IIVXB_INT Init(int value)
        {
            base.Init(value);
            return this;
        }
    }

    partial class MO
    {
        public decimal Value
        {
            get
            {
                decimal result = 0;
                if (Decimal.TryParse(Element.value, NumberStyles.Float, Util.DEFAULT_CULTURE_INFO, out result))
                    return result;
                return 0;
            }
            set
            {
                Element.value = Convert.ToString(value, Util.DEFAULT_CULTURE_INFO);
            }
        }

        public IMO Init(decimal value)
        {
            this.Value = value;
            return this;
        }
    }

    partial class PIVL_PPD_TS
    {
        public bool InstitutionSpecified
        {
            get
            {
                return Element.institutionSpecified1;
            }
            set
            {
                Element.institutionSpecified1 = value;
            }
        }
    }

    partial class PIVL_TS
    {
        public bool InstitutionSpecified
        {
            get
            {
                return Element.institutionSpecified1;
            }
            set
            {
                Element.institutionSpecified1 = value;
            }
        }
    }

    partial class PN : EN, IPN
    {
        public new IENXPCollection Items
        {
            get
            {
                return base.Items;
            }
        }

        public string FindENFamily()
        {
            if (Element.Items == null)
                return String.Empty;

            foreach (var t in this.Element.Items)
            {
                if (t is HL7SDK.Xml.Cda.enfamily && t.Text != null)
                    return String.Join("", t.Text);
            }
            return String.Empty;
        }

        public string FindENGiven()
        {
            if (Element.Items == null)
                return String.Empty;

            foreach (var t in this.Element.Items)
            {
                if (t is HL7SDK.Xml.Cda.engiven && t.Text != null)
                    return String.Join("", t.Text);
            }
            return String.Empty;
        }

        public string FindENSuffix()
        {
            foreach (var t in this.Element.Items)
            {
                if (t is HL7SDK.Xml.Cda.ensuffix && t.Text != null)
                    return String.Join("", t.Text);
            }
            return String.Empty;
        }
    }

    partial class PQ
    {
        public double Value
        {
            get
            {
                double result = 0;
                if (double.TryParse(Element.value, NumberStyles.Any, Util.DEFAULT_CULTURE_INFO, out result))
                    return result;
                return 0;
            }
            set
            {
                Element.value = Convert.ToString(value, Util.DEFAULT_CULTURE_INFO);
            }
        }

        public IPQ Init(double value)
        {
            this.Value = value;
            return this;
        }
    }
    partial class PQR
    {
        public double Value
        {
            get
            {
                if (String.IsNullOrWhiteSpace(Element.value))
                    return 0;
                return Convert.ToDouble(Element.value, Util.DEFAULT_CULTURE_INFO);
            }
            set
            {
                Element.value = Convert.ToString(value, Util.DEFAULT_CULTURE_INFO);
            }
        }
    }

    partial class REAL
    {
        public double Value
        {
            get
            {
                double result = 0;
                if (double.TryParse(Element.value, NumberStyles.Any, Util.DEFAULT_CULTURE_INFO, out result))
                    return result;
                return 0;
            }
            set
            {
                Element.value = Convert.ToString(value, Util.DEFAULT_CULTURE_INFO);
            }
        }

        public IREAL Init(double value)
        {
            this.Value = value;
            return this;
        }
    }

    partial class RTO_QTY_QTY
    {
        public IQTY Denominator
        {
            get
            {
                if (element == null)
                    return null;
                return ElementFactory.Wrap(Element.denominator, parent) as IQTY;
            }
            set
            {
                if (value == null)
                {
                    element = null;
                }
                else
                {
                    QTY qty = value as QTY;
                    Element.denominator = qty.Element;
                }
            }
        }

        public IQTY Numerator
        {
            get
            {
                if (element == null)
                    return null;
                return ElementFactory.Wrap(Element.numerator, parent) as IQTY;
            }
            set
            {
                if (value == null)
                {
                    element = null;
                }
                else
                {
                    QTY qty = value as QTY;
                    Element.numerator = qty.Element;
                }
            }
        }
    }
    partial class SLIST_PQ : ISLIST_PQ
    {
        public int[] AsArray
        {
            get
            {
                if (String.IsNullOrWhiteSpace(Element.digits))
                    return new int[0];

                List<int> result = new List<int>();
                foreach (var s in Element.digits.Split(' '))
                {
                    result.Add(Convert.ToInt32(s, Util.DEFAULT_CULTURE_INFO));
                }
                return result.ToArray();
            }
            set
            {
                if (value == null)
                {
                    Element.digits = String.Empty;
                    return;
                }
                foreach (var i in value)
                {
                    Element.digits = String.Join(" ", value);
                }
            }
        }
    }

    partial class SLIST_TS : ISLIST_TS
    {

        public int[] AsArray
        {
            get
            {
                if (String.IsNullOrWhiteSpace(Element.digits))
                    return new int[0];

                List<int> result = new List<int>();
                foreach (var s in Element.digits.Split(' '))
                {
                    result.Add(Convert.ToInt32(s, Util.DEFAULT_CULTURE_INFO));
                }
                return result.ToArray();
            }
            set
            {
                if (value == null)
                {
                    Element.digits = String.Empty;
                    return;
                }
                foreach (var i in value)
                {
                    Element.digits = String.Join(" ", value);
                }
            }
        }
    }
    partial class TS
    {
        public DateTime AsDateTime
        {
            get
            {
                var dt = Util.StringToDateTime(Element.value);
                if (dt == null)
                    throw new FormatException(String.Format("Cannot convert value \"{0}\" to TS", Element.value));
                return dt.Value;
            }
            set
            {
                Element.value = value.ToString("yyyyMMddHHmmss");
            }
        }

        public bool DateTimeSpecified
        {
            get
            {
                var dt = Util.StringToDateTime(Element.value);
                if (dt == null)
                    return false;
                return true;
            }
        }

        public ITS Init(DateTime value)
        {
            AsDateTime = value;
            return this;
        }
    }
}