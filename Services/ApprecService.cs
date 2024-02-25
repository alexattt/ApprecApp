using MsgDeliveryFailReporting.Database;
using MsgDeliveryFailReporting.Database.Models;
using MsgDeliveryFailReporting.XmlParsing.Models.Elements;

namespace MsgDeliveryFailReporting.Services
{
	public class ApprecService
	{
        public AppRecDbContext _dbContext;

        public ApprecService()
        {
            _dbContext = new AppRecDbContext();
        }

        public async Task SaveApprec(AppRecXml appRecDTO)
        {
            var apprecToSave = new AppRec()
            {
                Id = appRecDTO.Id,
                MsgType = new MessageType()
                {
                    V = appRecDTO.MsgType.V,
                    DN = appRecDTO.MsgType.DN
                },
                MIGversion = appRecDTO.MIGversion,
                SoftwareName = appRecDTO.SoftwareName,
                SoftwareVersion = appRecDTO.SoftwareVersion,
                GenDate = appRecDTO.GenDate,
                Status = new Status()
                {
                    Status_V = appRecDTO.Status.V,
                    Status_DN = appRecDTO.Status.DN
                },
                Sender = new Sender()
                {
                    SenderId = appRecDTO.Sender.HCP.Inst?.Id ?? appRecDTO.Sender.HCP.HCProf?.Id,
					SenderName = appRecDTO.Sender.HCP.Inst?.Name ?? appRecDTO.Sender.HCP.HCProf?.Name
				},
                Receiver = new Receiver()
                {
					ReceiverId = appRecDTO.Receiver.HCP.Inst?.Id ?? appRecDTO.Receiver.HCP.HCProf?.Id,
					ReceiverName = appRecDTO.Receiver.HCP.Inst?.Name ?? appRecDTO.Receiver.HCP.HCProf?.Name
				}
            };

            await _dbContext.AppRecs.AddAsync(apprecToSave);

            foreach (var error in appRecDTO.Errors)
            {
                await _dbContext.Errors.AddAsync(new Error()
                {
                    Err_V = error.V,
                    Err_DN = error.DN,
                    Err_S = error.S,
                    Err_OT = error.OT,
                    AppRec = apprecToSave
                });
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
