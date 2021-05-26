using Debitsuccess.CustomerApi.Sdk.Response;
using System.Threading.Tasks;

namespace Debitsuccess.CustomerApi.Sdk.Client.ResourceClients
{
    public class SuspensionScheduleClient : ScheduleClient<SuspensionSchedule, SuspensionSchedules, Account>
    {
        #region Constructors
        public SuspensionScheduleClient(ApiConnectionSettings apiConnectionSettings) : base(apiConnectionSettings)
        {
        }

        public SuspensionScheduleClient(DsApiClient apiClient) : base(apiClient)
        {
        }
        #endregion

        #region Update Methods
        public async Task<SuspensionSchedule> Update(Request.UpdateSuspensionSchedule request, int resourceId, int parentId)
            => await Update(request, resourceId.ToString(), parentId.ToString());
        public async Task<SuspensionSchedule> Update(Request.UpdateSuspensionSchedule request, string resourceId, string parentId)
        {
            return await this._apiClient.Patch<Request.UpdateSuspensionSchedule, SuspensionSchedule, Account>(request, resourceId, parentId);
        }
        #endregion
    }
}
