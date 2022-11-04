using Core.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspect.Autofac
{// Authorization aspectleri business'a yazılır. Sebebi her projede farklı yetkilendirme algoritmaları kullanılabileceğindendir.
    public class SecuredOperation : MethodInterception
    {
        //JWT için
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; //İstek yapıldığında binlerce kişi de istek yapabileceği için,herkese özel bir thread oluşturur.

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); // Split, metni belirtilen karaktere göre ayırıp array'e atıyo
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>(); // ServiceTool, injection altyapısını aynen okumamıza yarayacak.

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
