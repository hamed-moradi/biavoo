using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presentation.desktopApp.helper {
    public class IPValidator {
        public static string Exec(string currentInput) {
            var ip = new byte[4];
            var parted = currentInput.Split('.');
            var remaining = string.Empty;
            for(byte index = 0; index < parted.Length; index++) {
                var stack = remaining + parted[index];
                if(byte.TryParse(remaining + parted[index], out byte part)) {
                    stack = part.ToString();
                    if(stack.Count() > 3) {
                        remaining = stack.Substring(3);
                        stack = stack.Substring(0, 3);
                    }
                    ip[index] = part;
                }
                else {
                    ip[index] = 0;
                }
            }
            var result = string.Empty;
            for(var i = 0; i < ip.Length; i++) {
                if(i > 0)
                    result += ".";
                result += ip[i];
                for(var j = 0; j < 3 - ip[i].ToString().Length; j++)
                    result += " ";
            }
            return result;
            //return $"{ip[0]}.{ip[1]}.{ip[2]}.{ip[3]}";
            //return $"{(ip[0] > 0 ? ip[0].ToString() : "   ")}." +
            //    $"{(ip[1] > 0 ? ip[1].ToString() : "   ")}." +
            //    $"{(ip[2] > 0 ? ip[2].ToString() : "   ")}." +
            //    $"{(ip[3] > 0 ? ip[3].ToString() : "   ")}";
        }
    }
}
