﻿// <copyright file="DisabledMetricsTestStartup.cs" company="App Metrics Contributors">
// Copyright (c) App Metrics Contributors. All rights reserved.
// </copyright>

using App.Metrics.AspNetCore.Endpoints;
using App.Metrics.AspNetCore.Tracking;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace App.Metrics.AspNetCore.Integration.Facts.Startup
{
    public class DisabledMetricsTestStartup : TestStartup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMetricsEndpoint();
            app.UseMetricsAllMiddleware();

            SetupAppBuilder(app, env, loggerFactory);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var appMetricsOptions = new MetricsOptions
                                    {
                                        DefaultContextLabel = "testing",
                                        Enabled = false
                                    };

            var endpointsOptions = new MetricEndpointsOptions
                                   {
                                       MetricsTextEndpointEnabled = true,
                                       MetricsEndpointEnabled = true
                                   };

            var trackingOptions = new MetricsWebTrackingOptions();

            SetupServices(services, appMetricsOptions, trackingOptions, endpointsOptions);
        }
    }
}