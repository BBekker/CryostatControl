﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CryostatControlClient.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ICommandService")]
    public interface ICommandService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/IsAlive", ReplyAction="http://tempuri.org/ICommandService/IsAliveResponse")]
        bool IsAlive();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/IsAlive", ReplyAction="http://tempuri.org/ICommandService/IsAliveResponse")]
        System.Threading.Tasks.Task<bool> IsAliveAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/Cooldown", ReplyAction="http://tempuri.org/ICommandService/CooldownResponse")]
        bool Cooldown();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/Cooldown", ReplyAction="http://tempuri.org/ICommandService/CooldownResponse")]
        System.Threading.Tasks.Task<bool> CooldownAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/CooldownTime", ReplyAction="http://tempuri.org/ICommandService/CooldownTimeResponse")]
        bool CooldownTime(System.DateTime time);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/CooldownTime", ReplyAction="http://tempuri.org/ICommandService/CooldownTimeResponse")]
        System.Threading.Tasks.Task<bool> CooldownTimeAsync(System.DateTime time);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/Recycle", ReplyAction="http://tempuri.org/ICommandService/RecycleResponse")]
        bool Recycle();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/Recycle", ReplyAction="http://tempuri.org/ICommandService/RecycleResponse")]
        System.Threading.Tasks.Task<bool> RecycleAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/RecycleTime", ReplyAction="http://tempuri.org/ICommandService/RecycleTimeResponse")]
        bool RecycleTime(System.DateTime time);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/RecycleTime", ReplyAction="http://tempuri.org/ICommandService/RecycleTimeResponse")]
        System.Threading.Tasks.Task<bool> RecycleTimeAsync(System.DateTime time);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/Warmup", ReplyAction="http://tempuri.org/ICommandService/WarmupResponse")]
        bool Warmup();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/Warmup", ReplyAction="http://tempuri.org/ICommandService/WarmupResponse")]
        System.Threading.Tasks.Task<bool> WarmupAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/WarmupTime", ReplyAction="http://tempuri.org/ICommandService/WarmupTimeResponse")]
        bool WarmupTime(System.DateTime time);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/WarmupTime", ReplyAction="http://tempuri.org/ICommandService/WarmupTimeResponse")]
        System.Threading.Tasks.Task<bool> WarmupTimeAsync(System.DateTime time);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/Manual", ReplyAction="http://tempuri.org/ICommandService/ManualResponse")]
        bool Manual();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/Manual", ReplyAction="http://tempuri.org/ICommandService/ManualResponse")]
        System.Threading.Tasks.Task<bool> ManualAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/Cancel", ReplyAction="http://tempuri.org/ICommandService/CancelResponse")]
        bool Cancel();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/Cancel", ReplyAction="http://tempuri.org/ICommandService/CancelResponse")]
        System.Threading.Tasks.Task<bool> CancelAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/GetState", ReplyAction="http://tempuri.org/ICommandService/GetStateResponse")]
        int GetState();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/GetState", ReplyAction="http://tempuri.org/ICommandService/GetStateResponse")]
        System.Threading.Tasks.Task<int> GetStateAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/SetCompressorState", ReplyAction="http://tempuri.org/ICommandService/SetCompressorStateResponse")]
        bool SetCompressorState(bool status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/SetCompressorState", ReplyAction="http://tempuri.org/ICommandService/SetCompressorStateResponse")]
        System.Threading.Tasks.Task<bool> SetCompressorStateAsync(bool status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/WriteHelium7", ReplyAction="http://tempuri.org/ICommandService/WriteHelium7Response")]
        [System.ServiceModel.FaultContractAttribute(typeof(CryostatControlServer.HostService.DataContracts.CouldNotPerformActionFault), Action="http://tempuri.org/ICommandService/WriteHelium7CouldNotPerformActionFaultFault", Name="CouldNotPerformActionFault", Namespace="http://schemas.datacontract.org/2004/07/CryostatControlServer.HostService.DataCon" +
            "tracts")]
        bool WriteHelium7(int heater, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/WriteHelium7", ReplyAction="http://tempuri.org/ICommandService/WriteHelium7Response")]
        System.Threading.Tasks.Task<bool> WriteHelium7Async(int heater, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/ReadCompressorTemperatureScale", ReplyAction="http://tempuri.org/ICommandService/ReadCompressorTemperatureScaleResponse")]
        double ReadCompressorTemperatureScale();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/ReadCompressorTemperatureScale", ReplyAction="http://tempuri.org/ICommandService/ReadCompressorTemperatureScaleResponse")]
        System.Threading.Tasks.Task<double> ReadCompressorTemperatureScaleAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/ReadCompressorPressureScale", ReplyAction="http://tempuri.org/ICommandService/ReadCompressorPressureScaleResponse")]
        double ReadCompressorPressureScale();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/ReadCompressorPressureScale", ReplyAction="http://tempuri.org/ICommandService/ReadCompressorPressureScaleResponse")]
        System.Threading.Tasks.Task<double> ReadCompressorPressureScaleAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/ReadBlueforsHeaterPower", ReplyAction="http://tempuri.org/ICommandService/ReadBlueforsHeaterPowerResponse")]
        double ReadBlueforsHeaterPower();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/ReadBlueforsHeaterPower", ReplyAction="http://tempuri.org/ICommandService/ReadBlueforsHeaterPowerResponse")]
        System.Threading.Tasks.Task<double> ReadBlueforsHeaterPowerAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/WriteSettingValue", ReplyAction="http://tempuri.org/ICommandService/WriteSettingValueResponse")]
        bool WriteSettingValue(int setting, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/WriteSettingValue", ReplyAction="http://tempuri.org/ICommandService/WriteSettingValueResponse")]
        System.Threading.Tasks.Task<bool> WriteSettingValueAsync(int setting, double value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/ReadSettings", ReplyAction="http://tempuri.org/ICommandService/ReadSettingsResponse")]
        double[] ReadSettings();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/ReadSettings", ReplyAction="http://tempuri.org/ICommandService/ReadSettingsResponse")]
        System.Threading.Tasks.Task<double[]> ReadSettingsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/SetBlueforsHeater", ReplyAction="http://tempuri.org/ICommandService/SetBlueforsHeaterResponse")]
        bool SetBlueforsHeater(bool status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/SetBlueforsHeater", ReplyAction="http://tempuri.org/ICommandService/SetBlueforsHeaterResponse")]
        System.Threading.Tasks.Task<bool> SetBlueforsHeaterAsync(bool status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/StartLogging", ReplyAction="http://tempuri.org/ICommandService/StartLoggingResponse")]
        void StartLogging(int interval, bool[] logData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/StartLogging", ReplyAction="http://tempuri.org/ICommandService/StartLoggingResponse")]
        System.Threading.Tasks.Task StartLoggingAsync(int interval, bool[] logData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/StopLogging", ReplyAction="http://tempuri.org/ICommandService/StopLoggingResponse")]
        void StopLogging();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICommandService/StopLogging", ReplyAction="http://tempuri.org/ICommandService/StopLoggingResponse")]
        System.Threading.Tasks.Task StopLoggingAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ICommandServiceChannel : CryostatControlClient.ServiceReference1.ICommandService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class CommandServiceClient : System.ServiceModel.ClientBase<CryostatControlClient.ServiceReference1.ICommandService>, CryostatControlClient.ServiceReference1.ICommandService {
        
        public CommandServiceClient() {
        }
        
        public CommandServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public CommandServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommandServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public CommandServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool IsAlive() {
            return base.Channel.IsAlive();
        }
        
        public System.Threading.Tasks.Task<bool> IsAliveAsync() {
            return base.Channel.IsAliveAsync();
        }
        
        public bool Cooldown() {
            return base.Channel.Cooldown();
        }
        
        public System.Threading.Tasks.Task<bool> CooldownAsync() {
            return base.Channel.CooldownAsync();
        }
        
        public bool CooldownTime(System.DateTime time) {
            return base.Channel.CooldownTime(time);
        }
        
        public System.Threading.Tasks.Task<bool> CooldownTimeAsync(System.DateTime time) {
            return base.Channel.CooldownTimeAsync(time);
        }
        
        public bool Recycle() {
            return base.Channel.Recycle();
        }
        
        public System.Threading.Tasks.Task<bool> RecycleAsync() {
            return base.Channel.RecycleAsync();
        }
        
        public bool RecycleTime(System.DateTime time) {
            return base.Channel.RecycleTime(time);
        }
        
        public System.Threading.Tasks.Task<bool> RecycleTimeAsync(System.DateTime time) {
            return base.Channel.RecycleTimeAsync(time);
        }
        
        public bool Warmup() {
            return base.Channel.Warmup();
        }
        
        public System.Threading.Tasks.Task<bool> WarmupAsync() {
            return base.Channel.WarmupAsync();
        }
        
        public bool WarmupTime(System.DateTime time) {
            return base.Channel.WarmupTime(time);
        }
        
        public System.Threading.Tasks.Task<bool> WarmupTimeAsync(System.DateTime time) {
            return base.Channel.WarmupTimeAsync(time);
        }
        
        public bool Manual() {
            return base.Channel.Manual();
        }
        
        public System.Threading.Tasks.Task<bool> ManualAsync() {
            return base.Channel.ManualAsync();
        }
        
        public bool Cancel() {
            return base.Channel.Cancel();
        }
        
        public System.Threading.Tasks.Task<bool> CancelAsync() {
            return base.Channel.CancelAsync();
        }
        
        public int GetState() {
            return base.Channel.GetState();
        }
        
        public System.Threading.Tasks.Task<int> GetStateAsync() {
            return base.Channel.GetStateAsync();
        }
        
        public bool SetCompressorState(bool status) {
            return base.Channel.SetCompressorState(status);
        }
        
        public System.Threading.Tasks.Task<bool> SetCompressorStateAsync(bool status) {
            return base.Channel.SetCompressorStateAsync(status);
        }
        
        public bool WriteHelium7(int heater, double value) {
            return base.Channel.WriteHelium7(heater, value);
        }
        
        public System.Threading.Tasks.Task<bool> WriteHelium7Async(int heater, double value) {
            return base.Channel.WriteHelium7Async(heater, value);
        }
        
        public double ReadCompressorTemperatureScale() {
            return base.Channel.ReadCompressorTemperatureScale();
        }
        
        public System.Threading.Tasks.Task<double> ReadCompressorTemperatureScaleAsync() {
            return base.Channel.ReadCompressorTemperatureScaleAsync();
        }
        
        public double ReadCompressorPressureScale() {
            return base.Channel.ReadCompressorPressureScale();
        }
        
        public System.Threading.Tasks.Task<double> ReadCompressorPressureScaleAsync() {
            return base.Channel.ReadCompressorPressureScaleAsync();
        }
        
        public double ReadBlueforsHeaterPower() {
            return base.Channel.ReadBlueforsHeaterPower();
        }
        
        public System.Threading.Tasks.Task<double> ReadBlueforsHeaterPowerAsync() {
            return base.Channel.ReadBlueforsHeaterPowerAsync();
        }
        
        public bool WriteSettingValue(int setting, double value) {
            return base.Channel.WriteSettingValue(setting, value);
        }
        
        public System.Threading.Tasks.Task<bool> WriteSettingValueAsync(int setting, double value) {
            return base.Channel.WriteSettingValueAsync(setting, value);
        }
        
        public double[] ReadSettings() {
            return base.Channel.ReadSettings();
        }
        
        public System.Threading.Tasks.Task<double[]> ReadSettingsAsync() {
            return base.Channel.ReadSettingsAsync();
        }
        
        public bool SetBlueforsHeater(bool status) {
            return base.Channel.SetBlueforsHeater(status);
        }
        
        public System.Threading.Tasks.Task<bool> SetBlueforsHeaterAsync(bool status) {
            return base.Channel.SetBlueforsHeaterAsync(status);
        }
        
        public void StartLogging(int interval, bool[] logData) {
            base.Channel.StartLogging(interval, logData);
        }
        
        public System.Threading.Tasks.Task StartLoggingAsync(int interval, bool[] logData) {
            return base.Channel.StartLoggingAsync(interval, logData);
        }
        
        public void StopLogging() {
            base.Channel.StopLogging();
        }
        
        public System.Threading.Tasks.Task StopLoggingAsync() {
            return base.Channel.StopLoggingAsync();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IDataGet", CallbackContract=typeof(CryostatControlClient.ServiceReference1.IDataGetCallback), SessionMode=System.ServiceModel.SessionMode.Required)]
    public interface IDataGet {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDataGet/SubscribeForData")]
        void SubscribeForData(int interval);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDataGet/SubscribeForData")]
        System.Threading.Tasks.Task SubscribeForDataAsync(int interval);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDataGet/UnsubscribeForData")]
        void UnsubscribeForData();
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDataGet/UnsubscribeForData")]
        System.Threading.Tasks.Task UnsubscribeForDataAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDataGetCallback {
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDataGet/SendData")]
        void SendData(double[] data);
        
        [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IDataGet/SendModus")]
        void SendModus(int modus);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDataGetChannel : CryostatControlClient.ServiceReference1.IDataGet, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DataGetClient : System.ServiceModel.DuplexClientBase<CryostatControlClient.ServiceReference1.IDataGet>, CryostatControlClient.ServiceReference1.IDataGet {
        
        public DataGetClient(System.ServiceModel.InstanceContext callbackInstance) : 
                base(callbackInstance) {
        }
        
        public DataGetClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
                base(callbackInstance, endpointConfigurationName) {
        }
        
        public DataGetClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public DataGetClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, endpointConfigurationName, remoteAddress) {
        }
        
        public DataGetClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(callbackInstance, binding, remoteAddress) {
        }
        
        public void SubscribeForData(int interval) {
            base.Channel.SubscribeForData(interval);
        }
        
        public System.Threading.Tasks.Task SubscribeForDataAsync(int interval) {
            return base.Channel.SubscribeForDataAsync(interval);
        }
        
        public void UnsubscribeForData() {
            base.Channel.UnsubscribeForData();
        }
        
        public System.Threading.Tasks.Task UnsubscribeForDataAsync() {
            return base.Channel.UnsubscribeForDataAsync();
        }
    }
}
