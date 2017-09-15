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
                loadData(aData.id);
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

    var tb_ended = $('#tb_ended').DataTable({
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
            { "data": "end" },
            { "data": "timeRunning" },
            { "data": "timeAverage" }],

        "drawCallback": function (settings) {
            var pagination = $(this).closest('.dataTables_wrapper').find('.dataTables_paginate');
            pagination.toggle(this.api().page.info().pages > 1);
        },
        "fnInitComplete": function (oSettings, json) {

        }

    });

    var tb_failed = $('#tb_failed').DataTable({
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
            { "data": "end" },
            { "data": "timeRunning" },
            { "data": "timeAverage" },
            { "data": "reason" }],

        "drawCallback": function (settings) {
            var pagination = $(this).closest('.dataTables_wrapper').find('.dataTables_paginate');
            pagination.toggle(this.api().page.info().pages > 1);
        },
        "fnInitComplete": function (oSettings, json) {

        }

    });


    $('.dataTable').on('click', 'tbody tr', function () {
        //console.log('API row values : ', tb_tenants.row(this).data());
        loadData(tb_tenants.row(this).data().id);
    })

    function loadData(tenantId) {
        $('#div-spinner-running').show();
        $('#div-table-running').hide();
        $('#div-spinner-ended').show();
        $('#div-table-ended').hide();
        $('#div-spinner-failed').show();
        $('#div-table-failed').hide();


        tb_running.ajax.url('/api/tenants/' + tenantId + '/running').load(function (data) {
            // Hide spinner
            $('#div-spinner-running').hide();
            $('#div-table-running').show();
        });

        tb_ended.ajax.url('/api/tenants/' + tenantId + '/ended').load(function (data) {
            // Hide spinner
            $('#div-spinner-ended').hide();
            $('#div-table-ended').show();
        });

        tb_failed.ajax.url('/api/tenants/' + tenantId + '/failed').load(function (data) {
            // Hide spinner
            $('#div-spinner-failed').hide();
            $('#div-table-failed').show();
        });
    }


}); 