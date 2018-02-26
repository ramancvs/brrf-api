using BRRF.Core.BusinessManager.Interface;
using BRRF.DataAccess.Model;
using BRRF.SAM.Handlers.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BRRF.SAM.Handlers.Common.Extension;

namespace BRRF.SAM.Handlers.CommandHandler
{
    public class PostSurveyApprovalCommandHandler : HandlerBase, ICommandHandler<SurveyCommand>
    {
        public void Execute(SurveyCommand command)
        {
            LoadTenantConnection(command.BrandName);
            ApproveSurvey(command.Map());
        } 
    }
}
