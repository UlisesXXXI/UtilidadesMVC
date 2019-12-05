using Infraestructura.comun.Constantes;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Utilidades.Infraestructura.Managers.Imp;

namespace Utilidades.Infraestructura.Helpers.Controllers
{
    public class BaseController: Controller
    {
        
        private MessageManager _messageManager = new MessageManager();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

        }


        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            ManageMessages(filterContext);

            
        }

       

        protected void AddMessage(String message, MessageType type)
        {
            _messageManager.SetMessage(message, type);
        }

        private void ManageMessages(ActionExecutedContext filterContext)
        {
            if (filterContext.Result is JsonResult) return;

            List<Message> oldMessages =  TempData[MessageManagerConst.MESSAGES_TEMP_DATA] as List<Message>;
            if(oldMessages == null)
            {
                oldMessages = new List<Message>();
            }
            if (_messageManager.HasMessages)
            {
                foreach (var msg in _messageManager.Messages)
                {
                    oldMessages.Add(msg);
                }
            }

            TempData[MessageManagerConst.MESSAGES_TEMP_DATA] = oldMessages;
            
           
        }


    }
}