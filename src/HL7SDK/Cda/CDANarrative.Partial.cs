/******************************************************************************
 * 
 * HL7SDK CDA narrative elements
 * 
 *****************************************************************************/
using System;

namespace HL7SDK.Cda
{
    partial interface IStrucDocCaption
    {
        IStrucDocElementCollection Items
        {
            get;
        }
    }

    partial interface IStrucDocContent
    {
        IStrucDocElementCollection Items
        {
            get;
        }
    }

    partial interface IStrucDocFootnote
    {
        IStrucDocElementCollection Items
        {
            get;
        }
    }

    partial interface IStrucDocItem
    {
        IStrucDocElementCollection Items
        {
            get;
        }
    }

    partial interface IStrucDocLinkHtml
    {
        IStrucDocElementCollection Items
        {
            get;
        }
    }

    partial interface IStrucDocParagraph
    {
        IStrucDocElementCollection Items
        {
            get;
        }
    }

    partial interface IStrucDocTable
    {
        IStrucDocElementCollection Items
        {
            get;
        }
    }

    partial interface IStrucDocTd
    {
        IStrucDocElementCollection Items
        {
            get;
        }
    }

    partial interface IStrucDocText
    {
        IStrucDocElementCollection Items
        {
            get;
        }
    }

    partial interface IStrucDocTh
    {
        IStrucDocElementCollection Items
        {
            get;
        }
    }

    partial interface IStrucDocTr
    {
        IStrucDocElementCollection Items
        {
            get;
        }
    }

    partial class StrucDocBr
    {
    }

    partial class StrucDocCaption
    {
        public IStrucDocElementCollection Items
        {
            get
            {
                return new StrucDocElementCollection(
                    this,
                    () => { return Element.Items; },
                    (x) => { Element.Items = x; },
                    new Type[] 
                    {
                        typeof(HL7SDK.Xml.Cda.StrucDocFootnote),
                        typeof(HL7SDK.Xml.Cda.StrucDocFootnoteRef),
                        typeof(HL7SDK.Xml.Cda.StrucDocLinkHtml),
                        typeof(HL7SDK.Xml.Cda.StrucDocSub),
                        typeof(HL7SDK.Xml.Cda.StrucDocSup)
                    });

            }
        }
    }

    partial class StrucDocCol
    {
    }

    partial class StrucDocColgroup
    {
    }

    partial class StrucDocContent
    {
        public IStrucDocElementCollection Items
        {
            get
            {
                return new StrucDocElementCollection(
                    this,
                    () => { return Element.Items; },
                    (x) => { Element.Items = x; },
                    new Type[] 
                    {
                        typeof(string),
                        typeof(HL7SDK.Xml.Cda.StrucDocBr),
                        typeof(HL7SDK.Xml.Cda.StrucDocContent),
                        typeof(HL7SDK.Xml.Cda.StrucDocFootnote),
                        typeof(HL7SDK.Xml.Cda.StrucDocFootnoteRef),
                        typeof(HL7SDK.Xml.Cda.StrucDocLinkHtml),
                        typeof(HL7SDK.Xml.Cda.StrucDocRenderMultiMedia),
                        typeof(HL7SDK.Xml.Cda.StrucDocSub),
                        typeof(HL7SDK.Xml.Cda.StrucDocSup),
                    });

            }
        }
    }

    partial class StrucDocFootnote
    {
        public IStrucDocElementCollection Items
        {
            get
            {
                return new StrucDocElementCollection(
                    this,
                    () => { return Element.Items; },
                    (x) => { Element.Items = x; },
                    new Type[] 
                    {
                        typeof(HL7SDK.Xml.Cda.StrucDocBr),
                        typeof(HL7SDK.Xml.Cda.StrucDocContent),
                        typeof(HL7SDK.Xml.Cda.StrucDocLinkHtml),
                        typeof(HL7SDK.Xml.Cda.StrucDocList),
                        typeof(HL7SDK.Xml.Cda.StrucDocParagraph),
                        typeof(HL7SDK.Xml.Cda.StrucDocRenderMultiMedia),
                        typeof(HL7SDK.Xml.Cda.StrucDocSub),
                        typeof(HL7SDK.Xml.Cda.StrucDocSup),
                        typeof(HL7SDK.Xml.Cda.StrucDocTable),
                    });

            }
        }
    }

    partial class StrucDocFootnoteRef
    {
    }
    partial class StrucDocItem
    {
        public IStrucDocElementCollection Items
        {
            get
            {
                return new StrucDocElementCollection(
                    this,
                    () => { return Element.Items; },
                    (x) => { Element.Items = x; },
                    new Type[] 
                    {
                        typeof(HL7SDK.Xml.Cda.StrucDocBr),
                        typeof(HL7SDK.Xml.Cda.StrucDocContent),
                        typeof(HL7SDK.Xml.Cda.StrucDocFootnote),
                        typeof(HL7SDK.Xml.Cda.StrucDocFootnoteRef),
                        typeof(HL7SDK.Xml.Cda.StrucDocLinkHtml),
                        typeof(HL7SDK.Xml.Cda.StrucDocList),
                        typeof(HL7SDK.Xml.Cda.StrucDocParagraph),
                        typeof(HL7SDK.Xml.Cda.StrucDocRenderMultiMedia),
                        typeof(HL7SDK.Xml.Cda.StrucDocSub),
                        typeof(HL7SDK.Xml.Cda.StrucDocSup),
                        typeof(HL7SDK.Xml.Cda.StrucDocTable),
                    });

            }
        }
    }

    partial class StrucDocLinkHtml
    {
        public IStrucDocElementCollection Items
        {
            get
            {
                return new StrucDocElementCollection(
                    this,
                    () => { return Element.Items; },
                    (x) => { Element.Items = x; },
                    new Type[] 
                    {
                        typeof(HL7SDK.Xml.Cda.StrucDocFootnote),
                        typeof(HL7SDK.Xml.Cda.StrucDocFootnoteRef),
                    });

            }
        }
    }

    partial class StrucDocList
    {
    }

    partial class StrucDocParagraph
    {
        public IStrucDocElementCollection Items
        {
            get
            {
                return new StrucDocElementCollection(
                    this,
                    () => { return Element.Items; },
                    (x) => { Element.Items = x; },
                    new Type[] 
                    {
                        typeof(HL7SDK.Xml.Cda.StrucDocBr),
                        typeof(HL7SDK.Xml.Cda.StrucDocContent),
                        typeof(HL7SDK.Xml.Cda.StrucDocFootnote),
                        typeof(HL7SDK.Xml.Cda.StrucDocFootnoteRef),
                        typeof(HL7SDK.Xml.Cda.StrucDocLinkHtml),
                        typeof(HL7SDK.Xml.Cda.StrucDocRenderMultiMedia),
                        typeof(HL7SDK.Xml.Cda.StrucDocSub),
                        typeof(HL7SDK.Xml.Cda.StrucDocSup),
                    });

            }
        }
    }

    partial class StrucDocRenderMultiMedia
    {
    }

    partial class StrucDocSub
    {
    }

    partial class StrucDocSup
    {
    }

    partial class StrucDocTable
    {
        public IStrucDocElementCollection Items
        {
            get
            {
                return new StrucDocElementCollection(
                    this,
                    () => { return Element.Items; },
                    (x) => { Element.Items = x; },
                    new Type[] 
                    {
                        typeof(HL7SDK.Xml.Cda.StrucDocCol),
                        typeof(HL7SDK.Xml.Cda.StrucDocColgroup),
                    });

            }
        }
    }

    partial class StrucDocTd
    {
        public IStrucDocElementCollection Items
        {
            get
            {
                return new StrucDocElementCollection(
                    this,
                    () => { return Element.Items; },
                    (x) => { Element.Items = x; },
                    new Type[] 
                    {
                        typeof(HL7SDK.Xml.Cda.StrucDocBr),
                        typeof(HL7SDK.Xml.Cda.StrucDocContent),
                        typeof(HL7SDK.Xml.Cda.StrucDocFootnote),
                        typeof(HL7SDK.Xml.Cda.StrucDocFootnoteRef),
                        typeof(HL7SDK.Xml.Cda.StrucDocLinkHtml),
                        typeof(HL7SDK.Xml.Cda.StrucDocList),
                        typeof(HL7SDK.Xml.Cda.StrucDocParagraph),
                        typeof(HL7SDK.Xml.Cda.StrucDocRenderMultiMedia),
                        typeof(HL7SDK.Xml.Cda.StrucDocSub),
                        typeof(HL7SDK.Xml.Cda.StrucDocSup),
                    });

            }
        }
    }

    partial class StrucDocText
    {
        public IStrucDocElementCollection Items
        {
            get
            {
                return new StrucDocElementCollection(
                    this,
                    () => { return Element.Items; },
                    (x) => { Element.Items = x; },
                    new Type[] 
                    {
                        typeof(HL7SDK.Xml.Cda.StrucDocBr),
                        typeof(HL7SDK.Xml.Cda.StrucDocContent),
                        typeof(HL7SDK.Xml.Cda.StrucDocFootnote),
                        typeof(HL7SDK.Xml.Cda.StrucDocFootnoteRef),
                        typeof(HL7SDK.Xml.Cda.StrucDocLinkHtml),
                        typeof(HL7SDK.Xml.Cda.StrucDocList),
                        typeof(HL7SDK.Xml.Cda.StrucDocParagraph),
                        typeof(HL7SDK.Xml.Cda.StrucDocRenderMultiMedia),
                        typeof(HL7SDK.Xml.Cda.StrucDocSub),
                        typeof(HL7SDK.Xml.Cda.StrucDocSup),
                        typeof(HL7SDK.Xml.Cda.StrucDocTable),
                    });

            }
        }
    }

    partial class StrucDocTh
    {
        public IStrucDocElementCollection Items
        {
            get
            {
                return new StrucDocElementCollection(
                    this,
                    () => { return Element.Items; },
                    (x) => { Element.Items = x; },
                    new Type[] 
                    {
                        typeof(HL7SDK.Xml.Cda.StrucDocBr),
                        typeof(HL7SDK.Xml.Cda.StrucDocContent),
                        typeof(HL7SDK.Xml.Cda.StrucDocFootnote),
                        typeof(HL7SDK.Xml.Cda.StrucDocFootnoteRef),
                        typeof(HL7SDK.Xml.Cda.StrucDocLinkHtml),
                        typeof(HL7SDK.Xml.Cda.StrucDocRenderMultiMedia),
                        typeof(HL7SDK.Xml.Cda.StrucDocSub),
                        typeof(HL7SDK.Xml.Cda.StrucDocSup),
                    });

            }
        }
    }

    partial class StrucDocTr
    {
        public IStrucDocElementCollection Items
        {
            get
            {
                return new StrucDocElementCollection(
                    this,
                    () => { return Element.Items; },
                    (x) => { Element.Items = x; },
                    new Type[] 
                    {
                        typeof(HL7SDK.Xml.Cda.StrucDocTd),
                        typeof(HL7SDK.Xml.Cda.StrucDocTh),
                    });
            }
        }
    }

}