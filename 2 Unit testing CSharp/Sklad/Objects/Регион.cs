﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IIS.Sklad
{
    using System;
    using System.Xml;
    using ICSSoft.STORMNET;
    
    
    // *** Start programmer edit section *** (Using statements)

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Регион.
    /// </summary>
    // *** Start programmer edit section *** (Регион CustomAttributes)

    // *** End programmer edit section *** (Регион CustomAttributes)
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.none)]
    public class Регион : ICSSoft.STORMNET.DataObject
    {
        
        private string fНаименование;
        
        private string fКод;
        
        // *** Start programmer edit section *** (Регион CustomMembers)

        // *** End programmer edit section *** (Регион CustomMembers)

        
        /// <summary>
        /// Наименование.
        /// </summary>
        // *** Start programmer edit section *** (Регион.Наименование CustomAttributes)

        // *** End programmer edit section *** (Регион.Наименование CustomAttributes)
        [StrLen(255)]
        public virtual string Наименование
        {
            get
            {
                // *** Start programmer edit section *** (Регион.Наименование Get start)

                // *** End programmer edit section *** (Регион.Наименование Get start)
                string result = this.fНаименование;
                // *** Start programmer edit section *** (Регион.Наименование Get end)

                // *** End programmer edit section *** (Регион.Наименование Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Регион.Наименование Set start)

                // *** End programmer edit section *** (Регион.Наименование Set start)
                this.fНаименование = value;
                // *** Start programmer edit section *** (Регион.Наименование Set end)

                // *** End programmer edit section *** (Регион.Наименование Set end)
            }
        }
        
        /// <summary>
        /// Код.
        /// </summary>
        // *** Start programmer edit section *** (Регион.Код CustomAttributes)

        // *** End programmer edit section *** (Регион.Код CustomAttributes)
        [StrLen(255)]
        public virtual string Код
        {
            get
            {
                // *** Start programmer edit section *** (Регион.Код Get start)

                // *** End programmer edit section *** (Регион.Код Get start)
                string result = this.fКод;
                // *** Start programmer edit section *** (Регион.Код Get end)

                // *** End programmer edit section *** (Регион.Код Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Регион.Код Set start)

                // *** End programmer edit section *** (Регион.Код Set start)
                this.fКод = value;
                // *** Start programmer edit section *** (Регион.Код Set end)

                // *** End programmer edit section *** (Регион.Код Set end)
            }
        }
    }
}
