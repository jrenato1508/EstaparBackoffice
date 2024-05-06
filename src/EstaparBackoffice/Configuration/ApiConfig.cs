using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace EstaparBackoffice.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection AddApiConfig(this IServiceCollection services)
        {
            #region AddMemoryCache - Adicionando o Cahce de Memoria
            /* 
             * Link: https://www.youtube.com/watch?v=93VuXFslkLE
             
                Adicionar e configurar o Cache de Memoria na aplicação para usamos naquelas consultas que sofrem poucas ou nenhuma alteração
                mas são consultadas frequentemente no banco. Ex: FormaDePagamentoController. 

            OBS: O cache de memoria é recomendado para um servidor, não é endicado o uso de cache de memoria em sistemas distribuidos. Para
                 sistemas distribuidos o adequado é usar o Redis.

            Vantagem: Reduziremos a consultas ao banco de dados, ganhando maior velocidade nas consultas. Diminuimos os acessos simultaneos
                      ao banco de dados.
            Desvantagem:  Utilizaremos a memória do servidor para armazenar a consulta.

            ## CONFIGURAÇÃO ##

            1- Na class Program.cs  vamos adicionar o AddMemoryCache
                ex: services.AddMemoryCache();

            2- Agora vamos na Controller em que iremos utilizar a consulta em cache e adiciona injeção de Dependencia do IMemoryCache. e adicionaremos
               também uma chave que irá representar esse objeto na memória. 

               Como o MemoryCache é nativo do .Net não precisamos configurar a DI na nossa class de configuração de dependencia(DependencyInjectionConfig)
               
                ex: FormaDePagamentoController

                 private readonly IMemoryCache _memoryCache;
                 private const string FORMA_DE_PAGAMENTOS_KEY = "FORMAPAGAMENTOS";
                
                 public FormaPagamentoController(IMemoryCache memoryCache)
                 {
                    _memoryCache = memoryCache
                 }

            3 - Feita a configuração na controller, agora vamos na action que desejaremos usar o Cache
                ex:
                    public async Task<IEnumerable<FormasPagamentoViewModel>> ObterTodos()
                    {
                         // Checa se existe esse dado(FORMA_DE_PAGAMENTOS_KEY) alocado memoria
                         if(_memoryCache.TryGetValue(FORMA_DE_PAGAMENTOS_KEY, out IEnumerable<FormasPagamentoViewModel> formaPagamento))
                         {
                             return formaPagamento;
                         }

                         formaPagamento = _mapper.Map<IEnumerable< FormasPagamentoViewModel>>(await _FormaPagamentoRepository.ObterTodos());

                         _memoryCache.Set(PAGAMENTOS_KEY, formaPagamento);

                         return formaPagamento;

                    }

            4- Agora vamos adicionar o tempo de expiração desse cache e passar a configuração como parametro na hora em que formos adicionar
               a consulta em memoria chache

               AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600) - Tempos de expiração, ou seja, quando se passar 3600 segundos o
               cache será liberado(desalovado) da memória, o que forçará uma nova consulta ao banco de dados depois desse tempos.

               SlidingExpiration = TimeSpan.FromSeconds(1200) - Caso se passe 1200 segundos sem ninguém consultar a action, o cache será
               liberado(desalocado) da memória.
               ex:
            
                var memoryCacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600), 
                    SlidingExpiration = TimeSpan.FromSeconds(1200)
                };
                
                _memoryCache.Set(FORMA_DE_PAGAMENTOS_KEY, formaPagamento, memoryCacheEntryOptions);
             */
            #endregion
            services.AddMemoryCache();
            //services.AddControllers().ConfigureApiBehaviorOptions(setupAction => { setupAction.SuppressModelStateInvalidFilter = true; }); 
            services.AddControllers();

            services.AddApiVersioning(option =>
            {
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(1, 0);
                option.ReportApiVersions = true;
            })
                .AddApiExplorer(option =>
                {
                    option.GroupNameFormat = "'v'VVV";
                    option.SubstituteApiVersionInUrl = true;
                });



            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });



            return services;
        }


        public static IApplicationBuilder UseApiConfig(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();



            return app;
        }
    }
}
