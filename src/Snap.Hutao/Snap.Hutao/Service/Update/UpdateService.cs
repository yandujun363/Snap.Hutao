// Copyright (c) DGP Studio. All rights reserved.
// Licensed under the MIT license.

using Microsoft.UI.Xaml.Controls;
using Snap.Hutao.Core;
using Snap.Hutao.Core.LifeCycle;
using Snap.Hutao.Core.Setting;
using Snap.Hutao.Factory.ContentDialog;
using Snap.Hutao.Factory.Process;
using Snap.Hutao.Service.Hutao;
using Snap.Hutao.Service.Notification;
using Snap.Hutao.Web.Hutao;
using Snap.Hutao.Web.Hutao.Response;
using Snap.Hutao.Web.Response;

namespace Snap.Hutao.Service.Update;

[Service(ServiceLifetime.Singleton, typeof(IUpdateService))]
internal sealed partial class UpdateService : IUpdateService
{
    private const string UpdaterFilename = "Snap.Hutao.Deployment.exe";

    // Avoid injecting services directly
    private readonly IServiceProvider serviceProvider;

    [GeneratedConstructor]
    public partial UpdateService(IServiceProvider serviceProvider);

    public string? UpdateInfo { get; set; }

    public async ValueTask<CheckUpdateResult> CheckUpdateAsync(CancellationToken token = default)
    {
        // 直接返回"无需更新"，跳过所有网络检查
        CheckUpdateResult checkUpdateResult = new()
        {
            Kind = CheckUpdateResultKind.AlreadyUpdated
        };

        UpdateInfo = SH.ViewModelSettingAlreadyUpdated;
        return checkUpdateResult;
    }

    public async ValueTask TriggerUpdateAsync(CheckUpdateResult result, CancellationToken token = default)
    {
        // 更新功能已禁用，什么都不做
        return;
    }

    // 移除 LaunchUpdaterAsync 方法，因为不再需要
}