using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IO;
using System.ServiceModel.Web;
using Friendo.Framework.Common;
using Friendo.WCFService.WebRole1.Common;
using Friendo.DataStructure.EDM;
using Friendo.BusinessLogic.EDM;
using Friendo.DataStructure.Logger;

namespace Friendo.WCFService.WebRole1
{
    public class FriendoEDM : IFriendoEDM
    {
	public bool iam(){
		return true;
	}
	
	    public void Test()
		{
			int m  = 21;
		}
		public void Test2()
		{
		}
        /// <summary>
        /// 取得使用者電子報的狀態
        /// </summary>
        /// <param name="Callback">JSONP傳回使用值</param>
        /// <param name="AuthToken">驗證金鑰/權杖</param>
        /// <returns></returns>
        public Stream GetCancelNewsLetter(string Callback, string AuthToken)
        {
            try
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
                ReturnMessage rtnMsg = new ReturnMessage();
                Common.JSerializer jConvert = null;

                Friendo.WCFService.WebRole1.FriendoMission.CheckAuthToken checkToken = new Friendo.WCFService.WebRole1.FriendoMission.CheckAuthToken();
                checkToken.ToCheckAuthToken(AuthToken);

                if (!checkToken.IsSuccess)
                {
                    rtnMsg.IsSuccess = checkToken.IsSuccess;
                    rtnMsg.ErrorCode = 1;
                    rtnMsg.ErrorMessage = checkToken.Content;

                    jConvert = new Common.JSerializer(rtnMsg, Callback);
                    return jConvert.JSONstring;
                }

                Coupling coupling = new Coupling();
                ReturnMessage<GetCancelNewsLetterInput> rtnMsgT = coupling.CouplingToDataStructure<GetCancelNewsLetterInput>(new GetCancelNewsLetterInput(), "GetCancelNewsLetter", checkToken.Content);

                if (rtnMsgT.IsSuccess)
                {
                    EDM BLEDM = new EDM();
                    rtnMsg = BLEDM.GetCancelNewsLetter(rtnMsgT.ReturnData);
                }
                else
                {
                    rtnMsg.IsSuccess = rtnMsgT.IsSuccess;
                    rtnMsg.ErrorCode = 1;
                    rtnMsg.ErrorMessage = "資料查詢失敗";
                }

                jConvert = new Common.JSerializer(rtnMsg, Callback);
                return jConvert.JSONstring;
            }
            catch (Exception Ex)
            {
                BusinessLogic.Logger.ErrorLog(new ErrorLogInput() { FuncName = "EDM.svc GetCancelNewsLetter", Source = Ex.Source, Message = Ex.Message });

                Common.JSerializer jConvert = new Common.JSerializer(new ReturnMessage { IsSuccess = false, ErrorCode = 2, ErrorMessage = "資料查詢失敗" }, Callback);
                return jConvert.JSONstring;
            }
        }

        /// <summary>
        /// 新增使用者取消電子報紀錄
        /// </summary>
        /// <param name="AuthToken">驗證金鑰/權杖</param>
        /// <param name="Reason">原因</param>
        /// <returns></returns>
        public Stream InsertCancelNewsLetter(string AuthToken, string Reason)
        {
            try
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
                ReturnMessage rtnMsg = new ReturnMessage();
                Common.JSerializer jConvert = null;

                Friendo.WCFService.WebRole1.FriendoMission.CheckAuthToken checkToken = new Friendo.WCFService.WebRole1.FriendoMission.CheckAuthToken();
                checkToken.ToCheckAuthToken(AuthToken);

                if (!checkToken.IsSuccess)
                {
                    rtnMsg.IsSuccess = checkToken.IsSuccess;
                    rtnMsg.ErrorCode = 1;
                    rtnMsg.ErrorMessage = checkToken.Content;

                    jConvert = new Common.JSerializer(rtnMsg, null);
                    return jConvert.JSONstring;
                }

                Coupling coupling = new Coupling();
                ReturnMessage<InsertCancelNewsLetterInput> rtnMsgT = coupling.CouplingToDataStructure<InsertCancelNewsLetterInput>(new InsertCancelNewsLetterInput(), "InsertCancelNewsLetter", checkToken.Content, Reason);

                if (rtnMsgT.IsSuccess)
                {
                    EDM BLEDM = new EDM();
                    rtnMsg = BLEDM.InsertCancelNewsLetter(rtnMsgT.ReturnData);
                }
                else
                {
                    rtnMsg.IsSuccess = rtnMsgT.IsSuccess;
                    rtnMsg.ErrorCode = 1;
                    rtnMsg.ErrorMessage = "資料查詢失敗";
                }

                jConvert = new Common.JSerializer(rtnMsg, null);
                return jConvert.JSONstring;
            }
            catch (Exception Ex)
            {
                BusinessLogic.Logger.ErrorLog(new ErrorLogInput() { FuncName = "EDM.svc InsertCancelNewsLetter", Source = Ex.Source, Message = Ex.Message });

                Common.JSerializer jConvert = new Common.JSerializer(new ReturnMessage { IsSuccess = false, ErrorCode = 2, ErrorMessage = "資料寫入失敗" }, null);
                return jConvert.JSONstring;
            }
        }

        /// <summary>
        /// 刪除使用者取消電子報紀錄
        /// </summary>
        /// <param name="AuthToken">驗證金鑰/權杖</param>
        /// <returns></returns>
        public Stream DelCancelNewsLetter(string AuthToken)
        {
            try
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
                ReturnMessage rtnMsg = new ReturnMessage();
                Common.JSerializer jConvert = null;

                Friendo.WCFService.WebRole1.FriendoMission.CheckAuthToken checkToken = new Friendo.WCFService.WebRole1.FriendoMission.CheckAuthToken();
                checkToken.ToCheckAuthToken(AuthToken);

                if (!checkToken.IsSuccess)
                {
                    rtnMsg.IsSuccess = checkToken.IsSuccess;
                    rtnMsg.ErrorCode = 1;
                    rtnMsg.ErrorMessage = checkToken.Content;

                    jConvert = new Common.JSerializer(rtnMsg, null);
                    return jConvert.JSONstring;
                }

                Coupling coupling = new Coupling();
                ReturnMessage<DelCancelNewsLetterInput> rtnMsgT = coupling.CouplingToDataStructure<DelCancelNewsLetterInput>(new DelCancelNewsLetterInput(), "DelCancelNewsLetter", checkToken.Content);

                if (rtnMsgT.IsSuccess)
                {
                    EDM BLEDM = new EDM();
                    rtnMsg = BLEDM.DelCancelNewsLetter(rtnMsgT.ReturnData);
                }
                else
                {
                    rtnMsg.IsSuccess = rtnMsgT.IsSuccess;
                    rtnMsg.ErrorCode = 1;
                    rtnMsg.ErrorMessage = "資料查詢失敗";
                }

                jConvert = new Common.JSerializer(rtnMsg, null);
                return jConvert.JSONstring;
            }
            catch (Exception Ex)
            {
                BusinessLogic.Logger.ErrorLog(new ErrorLogInput() { FuncName = "EDM.svc DelCancelNewsLetter", Source = Ex.Source, Message = Ex.Message });

                Common.JSerializer jConvert = new Common.JSerializer(new ReturnMessage { IsSuccess = false, ErrorCode = 2, ErrorMessage = "資料寫入失敗" }, null);
                return jConvert.JSONstring;
            }
        }

        /// <summary>
        /// 取得郵件樣板
        /// </summary>
        /// <param name="Callback">JSONP傳回使用值</param>
        /// <param name="AuthToken">驗證金鑰/權杖</param>
        /// <param name="MailTemplateType">郵件樣板型別</param>
        /// <param name="CultureID">文件編號</param>
        /// <returns></returns>
        public Stream GetMailTemplate(string Callback, string AuthToken, string MailTemplateType, string CultureID)
        {
            try
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
                ReturnMessage rtnMsg = new ReturnMessage();
                Common.JSerializer jConvert = null;

                Friendo.WCFService.WebRole1.FriendoMission.CheckAuthToken checkToken = new Friendo.WCFService.WebRole1.FriendoMission.CheckAuthToken();
                checkToken.ToCheckAuthToken(AuthToken);

                if (!checkToken.IsSuccess)
                {
                    rtnMsg.IsSuccess = checkToken.IsSuccess;
                    rtnMsg.ErrorCode = 1;
                    rtnMsg.ErrorMessage = checkToken.Content;

                    jConvert = new Common.JSerializer(rtnMsg, Callback);
                    return jConvert.JSONstring;
                }

                Coupling coupling = new Coupling();
                ReturnMessage<GetMailTemplateInput> rtnMsgT = coupling.CouplingToDataStructure<GetMailTemplateInput>(new GetMailTemplateInput(), "GetMailTemplate", MailTemplateType, CultureID);

                if (rtnMsgT.IsSuccess)
                {
                    EDM BLEDM = new EDM();
                    rtnMsg = BLEDM.GetMailTemplate(rtnMsgT.ReturnData);
                }
                else
                {
                    rtnMsg.IsSuccess = rtnMsgT.IsSuccess;
                    rtnMsg.ErrorCode = 1;
                    rtnMsg.ErrorMessage = "資料查詢失敗";
                }

                jConvert = new Common.JSerializer(rtnMsg, Callback);
                return jConvert.JSONstring;
            }
            catch (Exception Ex)
            {
                BusinessLogic.Logger.ErrorLog(new ErrorLogInput() { FuncName = "EDM.svc GetMailTemplate", Source = Ex.Source, Message = Ex.Message });

                Common.JSerializer jConvert = new Common.JSerializer(new ReturnMessage { IsSuccess = false, ErrorCode = 2, ErrorMessage = "資料查詢失敗" }, Callback);
                return jConvert.JSONstring;
            }
        }

        /// <summary>
        /// 篩選是會員的EMail名單
        /// </summary>
        /// <param name="Callback">JSONP傳回使用值</param>
        /// <param name="AuthToken">驗證金鑰/權杖</param>
        /// <param name="EMailList">信箱列表(透過,傳遞)</param>
        /// <returns></returns>
        public Stream GetFilterMemberEMail(string Callback, string AuthToken, string EMailList)
        {
            try
            {
                WebOperationContext.Current.OutgoingResponse.ContentType = "application/json; charset=utf-8";
                ReturnMessage rtnMsg = new ReturnMessage();
                Common.JSerializer jConvert = null;

                Friendo.WCFService.WebRole1.FriendoMission.CheckAuthToken checkToken = new Friendo.WCFService.WebRole1.FriendoMission.CheckAuthToken();
                checkToken.ToCheckAuthToken(AuthToken);

                if (!checkToken.IsSuccess)
                {
                    rtnMsg.IsSuccess = checkToken.IsSuccess;
                    rtnMsg.ErrorCode = 1;
                    rtnMsg.ErrorMessage = checkToken.Content;

                    jConvert = new Common.JSerializer(rtnMsg, Callback);
                    return jConvert.JSONstring;
                }

                Coupling coupling = new Coupling();
                ReturnMessage<GetFilterMemberEMailInput> rtnMsgT = coupling.CouplingToDataStructure<GetFilterMemberEMailInput>(new GetFilterMemberEMailInput(), "GetFilterMemberEMail", EMailList);

                if (rtnMsgT.IsSuccess)
                {
                    EDM BLEDM = new EDM();
                    rtnMsg = BLEDM.GetFilterMemberEMail(rtnMsgT.ReturnData);
                }
                else
                {
                    rtnMsg.IsSuccess = rtnMsgT.IsSuccess;
                    rtnMsg.ErrorCode = 1;
                    rtnMsg.ErrorMessage = "資料查詢失敗";
                }

                jConvert = new Common.JSerializer(rtnMsg, Callback);
                return jConvert.JSONstring;
            }
            catch (Exception Ex)
            {
                BusinessLogic.Logger.ErrorLog(new ErrorLogInput() { FuncName = "EDM.svc GetFilterMemberEMail", Source = Ex.Source, Message = Ex.Message });

                Common.JSerializer jConvert = new Common.JSerializer(new ReturnMessage { IsSuccess = false, ErrorCode = 2, ErrorMessage = "資料查詢失敗" }, Callback);
                return jConvert.JSONstring;
            }
        }
    }
}
