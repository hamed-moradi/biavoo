using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace presentation.desktopApp.helper {
    public class DNS {
        private static NetworkInterface GetActiveEthernetOrWifiNetworkInterface() {
            var Nic = NetworkInterface.GetAllNetworkInterfaces().FirstOrDefault(
                a => a.OperationalStatus == OperationalStatus.Up &&
                (a.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || a.NetworkInterfaceType == NetworkInterfaceType.Ethernet) &&
                a.GetIPProperties().GatewayAddresses.Any(g => g.Address.AddressFamily.ToString() == "InterNetwork"));

            return Nic;
        }

        public static void Set(string[] ips) {
            var CurrentInterface = GetActiveEthernetOrWifiNetworkInterface();
            if(CurrentInterface == null) return;

            var objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var objMOC = objMC.GetInstances();
            foreach(ManagementObject objMO in objMOC) {
                if((bool)objMO["IPEnabled"]) {
                    if(objMO["Description"].ToString().Equals(CurrentInterface.Description)) {
                        var objdns = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                        if(objdns != null) {
                            if(ips.Any()) {
                                objdns["DNSServerSearchOrder"] = ips;
                            }
                            else {
                                objdns["DNSServerSearchOrder"] = null;
                            }
                            objMO.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
                        }
                    }
                }
            }
        }

        //public static void t() {
        //    var mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
        //    var moc = mc.GetInstances();
        //    foreach(ManagementObject mo in moc) {
        //        if((bool)mo["IPEnabled"]) {
        //            var objdns = mo.GetMethodParameters("SetDNSServerSearchOrder");
        //            if(objdns != null) {
        //                string[] s = { "192.168.XX.X", "XXX.XX.X.XX" };
        //                objdns["DNSServerSearchOrder"] = s;
        //                mo.InvokeMethod("SetDNSServerSearchOrder", objdns, null);
        //            }
        //        }
        //    }
        //}
    }
}
