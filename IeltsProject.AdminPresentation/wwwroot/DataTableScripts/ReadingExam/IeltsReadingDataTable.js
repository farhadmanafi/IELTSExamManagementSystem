var DT_IeltsReadingList = function () {

    //$.fn.dataTable.Api.register('column().title()', function () {
    //    return $(this.header()).text().trim();
    //});

    var initTable1 = function () {
        // begin first table
        var table = $('#DT_IeltsReadingList').DataTable({
            responsive: true,
            // Pagination settings
            dom: `<'row'<'col-sm-12'tr>>
			<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7 dataTables_pager'lp>>`,
            // read more: https://datatables.net/examples/basic_init/dom.html
            buttons: [
                'print',
                'copyHtml5',
                'excelHtml5',
                'csvHtml5',
                'pdfHtml5',
            ],
            lengthMenu: [5, 10, 25, 50, 100, 200, 2000],

            pageLength: 10,

            language: {
                'lengthMenu': 'Display _MENU_',
                'infoFiltered': '',
                'processing': '<i class="fa fa-spinner fa-spin fa-3x fa-fw"></i><span class="sr-only">Loading...</span><br/><br/> <span>در حال خواندن اطلاعات</span> '
            },

            searchDelay: 500,
            processing: true,

            serverSide: true,
            ajax: {
                url: $('#DT_IeltsReadingList').data("url"),
                type: 'POST'
            },
            columns: [
                { "className": "dt-center", "data": "title", "autowidth": true },
                { "className": "dt-center", "data": "description", "autowidth": true },
                { "className": "dt-center", "data": "timerMinuties", "autowidth": true },
                {
                    "data": "isActive",
                    "className": "dt-center",
                    "orderable": false,
                    render: function (data, type, row) {
                        if (row.isActive == true) {
                            //return '<input id="' + row.id + '" type="checkbox" checked="checked" name="isActive">';
                            return '<i class="fas fa-check fa-fw" style="color: var(--fa-navy);"></i>';
                        }
                        else {
                            //return '<input id="' + row.id + '" type="checkbox" name="isActive">';
                            return '<i class="fas fa-times fa-fw" style="color: var(--fa-navy);"></i>';
                        }
                    }
                },
                {
                    "className": "dt-center",
                    "orderable": false,
                    render: function (data, type, row) {
                        return '<a class="btn btn-warning font-weight-bold mr-2"' +
                            'href="/IeltsExamReading/EditReadingExam_Load?Id=' + row.id + '" >ویرایش</a> '
                            //+ '<a class="btn btn-info font-weight-bold mr-2"' +
                            //'href="/IeltsExamReading/ReadingExamText_Load?Id=' + row.id + '" >مشاهده متن</a>'
                            + '<a class="btn btn-info font-weight-bold mr-2"' +
                            'href="/IeltsExamReading/ReadingQuestionList?Id=' + row.id + '" >سوالات</a>'
                            //+ '<a class="btn btn-success font-weight-bold mr-2"' +
                            //'href="/IeltsExamReading/IeltsUserScoreList?Id=' + row.id + '" >نتایج</a>'
                            + '<a class="btn btn-success font-weight-bold mr-2"' +
                            'href="/IeltsExamReading/ReadingSection_Load?Id=' + row.id + '" >لیست بخش ها</a>';
                    }
                },
            ],
            columnDefs: [{
                "defaultContent": "-",
                "targets": "_all"
            }],
            order: [[0, "desc"]]
        });

        $('#kt_search').on('click', function (e) {
            e.preventDefault();
            var params = {};
            $('.datatable-input').each(function () {
                var i = $(this).data('col-index');
                if (params[i]) {
                    params[i] += '|to|' + $(this).val();
                }
                else {
                    params[i] = $(this).val();
                }
            });
            $.each(params, function (i, val) {
                // apply search params to datatable
                table.column(i).search(val ? val : '', false, false);
            });
            table.table().draw();
        });

        $('#kt_reset').on('click', function (e) {
            e.preventDefault();
            $('.datatable-input').each(function () {
                $(this).val('');
                table.column($(this).data('col-index')).search('', false, false);
            });
            $('.datatable-select').each(function () {
                $(this).val('').trigger('change')
                table.column($(this).data('col-index')).search('', false, false);
            });
            table.table().draw();
        });

        //$('#kt_datepicker').datepicker({
        //    todayHighlight: true,
        //    templates: {
        //        leftArrow: '<i class="la la-angle-left"></i>',
        //        rightArrow: '<i class="la la-angle-right"></i>',
        //    },
        //});
        //$('.kt_datepicker input').pDatepicker({
        //    responsive: false,
        //    initialValue: false,
        //    persianDigit: false,
        //    format: 'L'
        //});
        $('#export_print').on('click', function (e) {
            e.preventDefault();
            table.button(0).trigger();
        });

        $('#export_copy').on('click', function (e) {
            e.preventDefault();
            table.button(1).trigger();
        });

        $('#export_excel').on('click', function (e) {
            e.preventDefault();
            table.button(2).trigger();
        });

        $('#export_csv').on('click', function (e) {
            e.preventDefault();
            table.button(3).trigger();
        });

        $('#export_pdf').on('click', function (e) {
            e.preventDefault();
            table.button(4).trigger();
        });
    };

    return {

        //main function to initiate the module
        init: function () {
            initTable1();
        },

    };

}();

jQuery(document).ready(function () {
    if (!$.fn.DataTable.isDataTable('#DT_IeltsReadingList')) {
        DT_IeltsReadingList.init();
    }
});


