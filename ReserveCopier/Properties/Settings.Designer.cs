﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ReserveCopier.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.3.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string InputPaths {
            get {
                return ((string)(this["InputPaths"]));
            }
            set {
                this["InputPaths"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("c:\\tmp")]
        public string OutputPath {
            get {
                return ((string)(this["OutputPath"]));
            }
            set {
                this["OutputPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Разностное относительно первой копии")]
        public string CopyModeValue {
            get {
                return ((string)(this["CopyModeValue"]));
            }
            set {
                this["CopyModeValue"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Еженедельно")]
        public string FullCopyPeriodic {
            get {
                return ((string)(this["FullCopyPeriodic"]));
            }
            set {
                this["FullCopyPeriodic"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string DayOfWeekCheck {
            get {
                return ((string)(this["DayOfWeekCheck"]));
            }
            set {
                this["DayOfWeekCheck"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public decimal periodicHours {
            get {
                return ((decimal)(this["periodicHours"]));
            }
            set {
                this["periodicHours"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("\"\"")]
        public string LastDiffPath {
            get {
                return ((string)(this["LastDiffPath"]));
            }
            set {
                this["LastDiffPath"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2020-01-01")]
        public global::System.DateTime LastDiffTime {
            get {
                return ((global::System.DateTime)(this["LastDiffTime"]));
            }
            set {
                this["LastDiffTime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2020-01-01")]
        public global::System.DateTime LastFullTime {
            get {
                return ((global::System.DateTime)(this["LastFullTime"]));
            }
            set {
                this["LastFullTime"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public decimal PeriodicMinutes {
            get {
                return ((decimal)(this["PeriodicMinutes"]));
            }
            set {
                this["PeriodicMinutes"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AutoScroolLog {
            get {
                return ((bool)(this["AutoScroolLog"]));
            }
            set {
                this["AutoScroolLog"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AutoStartCopy {
            get {
                return ((bool)(this["AutoStartCopy"]));
            }
            set {
                this["AutoStartCopy"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ParallelCopy {
            get {
                return ((bool)(this["ParallelCopy"]));
            }
            set {
                this["ParallelCopy"] = value;
            }
        }
    }
}
