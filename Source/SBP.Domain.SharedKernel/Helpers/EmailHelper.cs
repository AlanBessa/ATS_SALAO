using System;
using System.Collections.Specialized;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SBP.Domain.SharedKernel.Helpers
{
    public class EmailHelper
    {
        public static MailMessage FormatarTemplateDeContato(string nome, string email, string celular, string texto)
        {
            var md = new MailDefinition
            {
                From = WebConfigurationManager.AppSettings["Remetente"],
                IsBodyHtml = true,
                Subject = "Envio de Senha"
            };

            var replacements = new ListDictionary
            {
                {"<%NomeUsuario%>", nome},
                {"<%Email%>", email},
                {"<%DataDeEnvio%>", DateTime.Now.ToString()},
                {"<%Celular%>", celular},
                {"<%Mensagem%>", texto}
            };

            #region "Html da Newsletter"

            const string mensagem = @"<html>
                                        <head></head>
                                        <body>
                                            <table cellspacing='0' cellpadding='0' width='100%' border='0' bgcolor='#e8eaea' align='center'>
                                                <tbody>
                                                    <tr>
                                                        <td align='center'>
                                                            <table cellspacing='0' cellpadding='0' width='660' border='0'>
                                                                <tbody>
                                                                    <tr>
                                                                        <td align='left' width='220' height='111'>
                                                                            <a href='#' class=''>
                                                                                Logo        									
                                                                                <!--<img width='220' height='111' border='0' style='display:block;' alt='Sony Entertainment   Network' src='https://bay177.mail.live.com/Handlers/ImageProxy.mvc?bicild=&amp;canary=n1QjcPCNbtRvleZghjVImM7OR%2fXaigUlr29p0uOVz1U%3d0&amp;url=http%3a%2f%2ff.email.sonyentertainmentnetwork.com%2fi%2f38%2f2089092187%2f20140227_sony_transactional_sen_logo.gif'>-->
                                                                            </a>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table cellspacing='0' cellpadding='0' width='660' border='0' bgcolor='#3071a3'>
                                                                <tbody>
                                                                    <tr>
                                                                        <td width='20' height='40'>&nbsp;</td>
                                                                        <td align='left'>
                                                                            <font style='font-family:Arial, Helvetica, sans-serif;font-size:18px;color:#ffffff;'>Email de contato</font>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table cellspacing='0' cellpadding='0' width='660' border='0' bgcolor='#ffffff'>
                                                                <tbody>
                                                                    <tr>
                                                                        <td width='19'>&nbsp;</td>
                                                                        <td align='left'>
                                                                            <table cellspacing='0' cellpadding='0' border='0'>
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td height='19'>&nbsp;</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align='left'>
                                                                                            <font style='font-family:Arial, Helvetica, sans-serif;font-size:13px;color:#555555;'>
                                                                                                Mensagem vinda do formulário de contato do site institucional no dia <strong><%DataDeEnvio%></strong>.
                                                                                            </font>
                                                                                            <br>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height='19'>&nbsp;</td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td width='19'>&nbsp;</td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>     
                                                            <table cellspacing='0' cellpadding='0' width='660' border='0' bgcolor='#ffffff'>
                                                                <tbody>
                                                                    <tr>
                                                                        <td width='20'>&nbsp;</td>
                                                                        <td>
                                                                            <br>
                                                                            <table cellspacing='0' cellpadding='0' width='622' border='0'>
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td bgcolor='#E1E1E1' align='left'>
                                                                                            <table cellspacing='0' cellpadding='0' width='622' border='0'>
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td width='1' height='10'></td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                            <table cellspacing='0' cellpadding='0' width='622' border='0'>
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td width='10' bgcolor='#E1E1E1' height='2'></td>
                                                                                                        <td width='602' valign='top' align='left'>
                                                                                                            <table cellspacing='0' cellpadding='0' width='602' border='0'>
                                                                                                                <tbody>
                                                                                                                    <tr>
                                                                                                                        <td width='50' align='left'>
                                                                                                                            <font face='Arial, Helvetica, sans-serif' color='#333333' style='font-size:12px;'>Nome: </font>
                                                                                                                        </td>
                                                                                                                        <td width='10' bgcolor='#E1E1E1' height='2'></td>
                                                                                                                        <td>
                                                                                                                            <font face='Arial, Helvetica, sans-serif' color='#000000' style='font-size:12px;font-weight:bold;'><%NomeUsuario%></font>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </tbody>
                                                                                                            </table>
                                                                                                            <table cellspacing='0' cellpadding='0' width='602' border='0'>
                                                                                                                <tbody>
                                                                                                                    <tr>
                                                                                                                        <td width='50' align='left'>
                                                                                                                            <font face='Arial, Helvetica, sans-serif' color='#333333' style='font-size:12px;'>E-mail: </font>
                                                                                                                        </td>
                                                                                                                        <td width='10' bgcolor='#E1E1E1' height='2'></td>
                                                                                                                        <td>
                                                                                                                            <font face='Arial, Helvetica, sans-serif' color='#000000' style='font-size:12px;font-weight:bold;'><%Email%></font>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </tbody>
                                                                                                            </table>
                                                                                                            <table cellspacing='0' cellpadding='0' width='602' border='0'>
                                                                                                                <tbody>
                                                                                                                    <tr>
                                                                                                                        <td width='50' align='left'>
                                                                                                                            <font face='Arial, Helvetica, sans-serif' color='#333333' style='font-size:12px;'>Celular: </font>
                                                                                                                        </td>
                                                                                                                        <td width='10' bgcolor='#E1E1E1' height='2'></td>
                                                                                                                        <td>
                                                                                                                            <font face='Arial, Helvetica, sans-serif' color='#000000' style='font-size:12px;font-weight:bold;'><%Celular%></font>
                                                                                                                        </td>
                                                                                                                    </tr>
                                                                                                                </tbody>
                                                                                                            </table>                                                                    
                                                                                                            <table cellspacing='0' cellpadding='0' width='602' border='0'>
                                                                                                                <tbody>
                                                                                                                    <tr> 
                                                                                                                        <td width='1' height='10'></td>
                                                                                                                    </tr>
                                                                                                                </tbody>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                        <td width='10' height='2'></td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                            <br>            
                                                                            <table cellspacing='0' cellpadding='0' border='0' style='width:622px;'> 
                                                                                <tbody>
                                                                                    <tr> 
                                                                                        <td>
                                                                                            <table cellspacing='0' cellpadding='0' width='622' border='0'> 
                                                                                                <tbody>
                                                                                                    <tr> 
                                                                                                        <td valign='top' align='left'> 
                                                                                                            <table cellspacing='0' cellpadding='0' width='622' border='0'> 
                                                                                                                <tbody>
                                                                                                                    <tr> 
                                                                                                                        <td width='10' bgcolor='#252525' height='1'></td> 
                                                                                                                        <td width='602' valign='top' align='left'>
                                                                                                                            <table cellspacing='0' cellpadding='0' width='612' border='0'> 
                                                                                                                                <tbody>
                                                                                                                                    <tr>
                                                                                                                                        <td valign='top' bgcolor='#252525' align='left'>
                                                                                                                                            <table cellspacing='0' cellpadding='0' width='175' border='0'> 
                                                                                                                                                <tbody>
                                                                                                                                                    <tr> 
                                                                                                                                                        <td bgcolor='#252525' height='10'></td> 
                                                                                                                                                    </tr> 
                                                                                                                                                </tbody>
                                                                                                                                            </table> 
                                                                                                                                            <table cellspacing='0' cellpadding='0' width='175' border='0'> 
                                                                                                                                                <tbody>
                                                                                                                                                    <tr> 
                                                                                                                                                        <td width='175' bgcolor='#252525' align='left'>
                                                                                                                                                            <font face='Arial, Helvetica, sans-serif' color='#ffffff' style='font-size:12px;font-weight:bold;'>Mensagem</font>
                                                                                                                                                        </td> 
                                                                                                                                                    </tr> 
                                                                                                                                                </tbody>
                                                                                                                                            </table> 
                                                                                                                                            <table cellspacing='0' cellpadding='0' width='200' border='0'> 
                                                                                                                                                <tbody>
                                                                                                                                                    <tr> 
                                                                                                                                                        <td bgcolor='#252525' height='10'></td> 
                                                                                                                                                    </tr> 
                                                                                                                                                </tbody>
                                                                                                                                            </table>
                                                                                                                                        </td> 
                                                                                                                                    </tr> 
                                                                                                                                </tbody>
                                                                                                                            </table>
                                                                                                                        </td> 
                                                                                                                    </tr> 
                                                                                                                </tbody>
                                                                                                            </table>
                                                                                                        </td>
                                                                                                    </tr> 
                                                                                                </tbody>
                                                                                            </table> 
                                                                                        </td> 
                                                                                    </tr> 
                                                                                </tbody>
                                                                            </table>
                                                                            <table cellspacing='0' cellpadding='0' border='0' style='width:622px;'> 
                                                                                <tbody>
                                                                                    <tr> 
                                                                                        <td>
                                                                                            <table cellspacing='0' cellpadding='0' width='622' border='0'> 
                                                                                                <tbody>
                                                                                                    <tr> 
                                                                                                        <td valign='top' align='left'> 
                                                                                                            <table cellspacing='0' cellpadding='0' width='622' border='0'> 
                                                                                                                <tbody>
                                                                                                                    <tr> 
                                                                                                                        <td width='10' bgcolor='#E1E1E1' height='1'></td> 
                                                                                                                        <td width='602' valign='top' align='left'>
                                                                                                                            <table cellspacing='0' cellpadding='0' width='612' border='0'> 
                                                                                                                                <tbody>
                                                                                                                                    <tr>
                                                                                                                                        <td valign='top' bgcolor='#E1E1E1' align='left'>
                                                                                                                                            <table cellspacing='0' cellpadding='0' width='175' border='0'> 
                                                                                                                                                <tbody>
                                                                                                                                                    <tr> 
                                                                                                                                                        <td bgcolor='#E1E1E1' height='10'></td> 
                                                                                                                                                    </tr> 
                                                                                                                                                </tbody>
                                                                                                                                            </table> 
                                                                                                                                            <table cellspacing='0' cellpadding='0' width='175' border='0'> 
                                                                                                                                                <tbody>
                                                                                                                                                    <tr> 
                                                                                                                                                        <td width='175' bgcolor='#E1E1E1' align='left'>
                                                                                                                                                            <font face='Arial, Helvetica, sans-serif' color='#000000' style='font-size:12px;'><%Mensagem%></font>
                                                                                                                                                        </td> 
                                                                                                                                                    </tr> 
                                                                                                                                                </tbody>
                                                                                                                                            </table> 
                                                                                                                                            <table cellspacing='0' cellpadding='0' width='200' border='0'> 
                                                                                                                                                <tbody>
                                                                                                                                                    <tr> 
                                                                                                                                                        <td bgcolor='#E1E1E1' height='10'></td> 
                                                                                                                                                    </tr> 
                                                                                                                                                </tbody>
                                                                                                                                            </table>
                                                                                                                                        </td> 
                                                                                                                                    </tr> 
                                                                                                                                </tbody>
                                                                                                                            </table>
                                                                                                                        </td> 
                                                                                                                    </tr> 
                                                                                                                </tbody>
                                                                                                            </table>
                                                                                                        </td> 
                                                                                                    </tr> 
                                                                                                </tbody>
                                                                                            </table> 
                                                                                        </td> 
                                                                                    </tr> 
                                                                                </tbody>
                                                                            </table>            
                                                                            <table cellspacing='0' cellpadding='0' width='620' border='0'>
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td height='20'>&nbsp;</td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>          
                                                                        </td>
                                                                        <td width='20'>&nbsp;</td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>           				
                                                            <table cellspacing='0' cellpadding='0' width='660' border='0' bgcolor='#ffffff'>
                                                                <tbody>
                                                                    <tr>
                                                                        <td width='20'>&nbsp;</td>
                                                                        <td>
                                                                            <table cellspacing='0' cellpadding='0' border='0'>
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td height='20'>&nbsp;</td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td align='left'>
                                                                                            <font style='font-family:Arial, Helvetica, sans-serif;font-size:13px;color:#555555;'></font>
                                                                                            <br>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td height='20'>&nbsp;</td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td width='20'>&nbsp;</td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table cellspacing='0' cellpadding='0' width='660' border='0'>
                                                                <tbody>
                                                                    <tr>
                                                                        <td height='20'></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align='center'>
                                                                            <font style='font-family:Arial, Helvetica, sans-serif;font-size:11px;color:#555555;'>
                                                                                Esta mensagem de e-mail foi enviada de um endereço de e-mail que apenas envia mensagens. Não responda a esta mensagem. Para obter mais informações sobre sua conta, visite os links abaixo.
                                                                                <br>
                                                                                <br>
                                                                                Suporte:
                                                                                <br>
                                                                                <a target='_blank' href='#' style='color:#0099cc;'>http://www.teste.com/contactus/</a>
                                                                                <br>
                                                                                <br>
                                                                                Termos de uso e Política de privacidade:
                                                                                <br>
                                                                                <a target='_blank' href='#' style='color:#0099cc;'>http://www.teste.com/legal/</a>
                                                                            </font>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td height='45' align='center'>&nbsp;</td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </body>";
            #endregion
            
            return md.CreateMailMessage(email, replacements, mensagem, new Control());
        }

        public static void EnviarEmail(MailMessage mailMessage, bool isEnableSsl)
        {
            var usuario = WebConfigurationManager.AppSettings["usuario"];
            var senha = WebConfigurationManager.AppSettings["senha"];

            var smtp = new SmtpClient
            {
                Host = WebConfigurationManager.AppSettings["Host"],
                EnableSsl = isEnableSsl,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(usuario, senha)
            };

            smtp.Send(mailMessage);
        }
    }
}
