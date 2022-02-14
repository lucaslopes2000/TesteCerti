using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TesteCerti.API.Models;

namespace TesteCerti.API.Controllers
{
    [ApiController]
    [Route("")]
    public class TradutorController : ControllerBase
    {
        public TradutorController()
        {
            
        }

        [HttpGet("{number}")]
        public Tradutor Get(int number)
        {
            string name = string.Empty;

            if (number > 99999 | number < -99999){
                return new Tradutor() {
                    Extenso = "Esse numero não é permitido!"
                };
            }else{
                string strNumber = number.ToString("00000");
                
                if (strNumber.Substring(0,1) == "-") {
                    name += "menos ";
                    strNumber = strNumber.Remove(0,1);
                }
                
                for (int n = 0; n <= 4; n++) {
                    if (n == 0){
                        name += StrDezena(strNumber.Substring(n,1));
                    };
                    
                    if (n == 1) {
                        if (strNumber.Substring(n-1,1) == "0") {
                            if (strNumber.Substring(n,1) == "0") name += string.Empty;
                            else name += StrUnidade(strNumber.Substring(n,1));

                            if (strNumber.Substring(n,1) != "0") name += "mil ";
                        }else if (strNumber.Substring(n-1,1) == "1"){
                            name += StrDezenaEspecial(strNumber.Substring(n,1));

                            name += "mil ";
                        }else {
                            if (strNumber.Substring(n-1,1) != "0" & strNumber.Substring(n,1) == "0") {
                                name += "mil ";  
                            }else {
                                name += "e ";

                                name += StrUnidade(strNumber.Substring(n,1));

                                name += "mil ";
                            }
                        };
                    };
                    
                    if (n == 2) {
                        if (name != string.Empty & strNumber.Substring(n,1) != "0") name += "e ";

                        name += StrCentena(strNumber.Substring(n,1), strNumber.Substring(n+1,1), strNumber.Substring(n+2,1));                       
                    };

                    if (n == 3) {
                        if (name != string.Empty & strNumber.Substring(n,1) != "0") name += "e ";
                      
                        name += StrDezena(strNumber.Substring(n,1));
                    };

                    if (n == 4) {
                        if (strNumber.Substring(n-1,1) == "1") {
                            name += StrDezenaEspecial(strNumber.Substring(n,1));
                        }else if (name == string.Empty & strNumber.Substring(n,1) == "0") {
                            name = "zero ";
                        }else {
                            if (name != string.Empty & strNumber.Substring(n,1) != "0") name += "e ";

                            name += StrUnidade(strNumber.Substring(n,1));
                        }
                    };
                };
                
                return new Tradutor() {
                    Extenso = name
                };
            };
        }

        public static string StrUnidade (string position) {
            string str = string.Empty;

            if (position == "1") str += "um ";
            else if (position == "2") str += "dois ";
            else if (position == "3") str += "tres ";
            else if (position == "4") str += "quatro ";
            else if (position == "5") str += "cinco ";
            else if (position == "6") str += "seis ";
            else if (position == "7") str += "sete ";
            else if (position == "8") str += "oito ";
            else if (position == "9") str += "nove ";

            return str;
        }

        public static string StrDezena (string position) {
            string str = string.Empty;

            if (position == "0") str += string.Empty;
            else if (position == "2") str += "vinte ";
            else if (position == "3") str += "trinta ";
            else if (position == "4") str += "quarenta ";
            else if (position == "5") str += "cinquenta ";
            else if (position == "6") str += "sessenta ";
            else if (position == "7") str += "setenta ";
            else if (position == "8") str += "oitenta ";
            else if (position == "9") str += "noventa ";

            return str;
        }

        public static string StrDezenaEspecial (string position) {
            string str = string.Empty;

            if (position == "0") str += "dez ";
            else if (position == "1") str += "onze ";
            else if (position == "2") str += "doze ";
            else if (position == "3") str += "treze ";
            else if (position == "4") str += "quatorze ";
            else if (position == "5") str += "quinze ";
            else if (position == "6") str += "dezesseis ";
            else if (position == "7") str += "dezessete ";
            else if (position == "8") str += "dezoito ";
            else if (position == "9") str += "dezenove ";

            return str;
        }

        public static string StrCentena (string position, string position2, string position3) {
            string str = string.Empty;

            if (position == "0") str += string.Empty;
            else if (position == "1") {
                if (position2 == "0" & position3 == "0") str += "cem ";
                else str += "cento ";
            }
            else if (position == "2") str += "duzentos ";
            else if (position == "3") str += "trezentos ";
            else if (position == "4") str += "quatrocentos ";
            else if (position == "5") str += "quinhentos ";
            else if (position == "6") str += "seiscentos ";
            else if (position == "7") str += "setecentos ";
            else if (position == "8") str += "oitocentos ";
            else if (position == "9") str += "novecentos ";

            return str;
        }
    }
}