﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.17929
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace VideoLibrary.Properties {
    
    
    [CompilerGenerated()]
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed partial class Settings : ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [ApplicationScopedSetting()]
        [DebuggerNonUserCode()]
        [SpecialSetting(SpecialSetting.ConnectionString)]
        [DefaultSettingValue("Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\App_Data\\VideoLibrar" +
            "yDB.mdf;Integrated Security=True")]
        public string VideoLibraryDBConnectionString {
            get {
                return ((string)(this["VideoLibraryDBConnectionString"]));
            }
        }
    }
}