$(document).ready(function () {
    $.fn.dataTable.ext.errMode = function (settings, helpPage, message) { console.log(message) };

    var tb_tenants = $('#tb_tenants').DataTable({
        "info": false,
        "oLanguage": { "sSearch": "" },
        "lengthChange": false,
        "ajax": {
            "url": "/api/tenants/",
            "dataSrc": ""
        },
        "columns": [
            { "data": "name" },
            { "data": "running" },
            { "data": "ended" },
            { "data": "failed" }],

        "drawCallback": function (settings) {
            var pagination = $(this).closest('.dataTables_wrapper').find('.dataTables_paginate');
            pagination.toggle(this.api().page.info().pages > 1);
        },

        "fnInitComplete": function (oSettings, json) {
            $('#div-spinner-tenant').hide();
            $('#div-table-tenant').show();
            if (oSettings.aoData.length > 0) {
                var aData = oSettings.aoData[0]._aData;
                tb_running.ajax.url('/api/tenants/1/running').load();
            }
        }
    });

    var tb_running = $('#tb_running').DataTable({
        "info": false,
        "searching": false,
        "oLanguage": { "sSearch": "" },
        "lengthChange": false,
        "ajax": {
            "dataSrc": ""
        },
        "columns": [
            { "data": "name" },
            { "data": "start" },
            { "data": "timeRunning" },
            { "data": "timeAverage" }],

        "drawCallback": function (settings) {
            var pagination = $(this).closest('.dataTables_wrapper').find('.dataTables_paginate');
            pagination.toggle(this.api().page.info().pages > 1);
        },
        "fnInitComplete": function (oSettings, json) {
            
        }

    });


    $('.dataTable').on('click', 'tbody tr', function () {
        console.log('API row values : ', tb_tenants.row(this).data());
    })

}); 