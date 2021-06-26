using Evento.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Evento.Permissions
{
    public class EventoPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(EventoPermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(EventoPermissions.MyPermission1, L("Permission:MyPermission1"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<EventoResource>(name);
        }
    }
}
