$(document).ready(function () {
    $.ajax({
        url: '/api/Employee/GetEmployeeDetails',
        method: 'get',
        dataType: 'json',
        success: function (data) {
            var table = $('#tblEmployeeDetails').DataTable({
                searching: false,
                paging: false,
                info: false,
                dom: 'Bfrtip',
                data: data,
                "fnRowCallback": function (nRow, data, iDisplayIndex) {
                    nRow.setAttribute('id', "row_" + data.employeeId);
                },
                columns: [
                    {
                        data: "employeeId"
                    },
                   {
                       data: "employeeName"
                   },
                   {
                       data: "age"
                   },
                   {
                       data: "address"
                   },
                   {
                       data: "phoneNo"
                   },
                   {
                       data: "employeeId",
                       render: function (data) {
                           return "<button class='btn btn-success edit'  data-movies-id=" + data + ">EDIT</button>"
                       },
                       orderable: false,
                   },
                   {
                       data: "employeeId",
                       render: function (data) {
                           return "<button class='btn btn-danger delete' data-movies-id=" + data + ">DELETE</button>"
                       },
                       orderable: false,
                   }
                ],
                columnDefs: [
                      {
                          "targets": [0],
                          className: "none",
                      }
                ]
            });
        }
    });

    //Edit
    $("#tblEmployeeDetails").on("click", ".edit", function () {
        const employeeId = $.trim($(this).closest("tr").find('td:eq(0)').text());
        const employeeName = $.trim($(this).closest("tr").find('td:eq(1)').text());
        const age = $.trim($(this).closest("tr").find('td:eq(2)').text());
        const address = $.trim($(this).closest("tr").find('td:eq(3)').text());
        const phoneNo = $.trim($(this).closest("tr").find('td:eq(4)').text());
        $("#hdnEmployeeId").val(employeeId);
        $("#txtEmployeeName").val(employeeName);
        $("#txtAge").val(age);
        $("#txtAddress").val(address);
        $("#txtPhoneNumber").val(phoneNo);
    });

    //Delete
    $("#tblEmployeeDetails").on("click", ".delete", function () {
        var Id = $.trim($(this).closest("tr").find('td:eq(0)').text());
        $(".modal").show();
        $("#btnOk").off('click').click(function () {
            $.ajax({
                method: "DELETE",
                url: "api/Employee/DeleteEmployee/" + Id,
                success: function (response) {
                    //removing the row from the table and then redrawing.
                    $('#tblEmployeeDetails').DataTable().row($("#row_" + Id)).remove().draw();
                    //$("#row_" + Id);
                    $(".modal").hide();
                    ShowMessage("Employee Deleted Successfully!.", 1);
                    $('.dataTables_scrollBody thead tr').css({
                        visibility: 'collapse'
                    });
                },
                error: function (error) {
                    ShowMessage("Error has Occured Please Contact Administrator.", 2);
                }
            });
        });
    });

    //Hide The pop up.
    $("#btnCancel").click(function () {
        $(".modal").hide();
    });

    //Hide The pop up.
    $("#btnClose").click(function () {
        $(".modal").hide();
    });

    function ShowMessage(message, messagetype) {
        var cssclass;
        switch (messagetype) {
            case 1:
                cssclass = 'alert alert-success'
                break;
            case 2:
                cssclass = 'alert alert-danger'
                break;
            case 3:
                cssclass = 'alert alert-warning'
                break;
            default:
                cssclass = 'alert alert-info'
        }
        showMsg(message, cssclass);
    }

    function showMsg(msg, msgClass) {
        clearMsg();
        $("#lblMsg").show();
        $("#lblMsg").text(msg).addClass(msgClass).fadeOut(3000);
    }

    function clearMsg() {
        $("#lblMsg").text("");
        $("#lblMsg").removeClass("");
    }
});