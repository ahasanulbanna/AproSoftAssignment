
$(document).ready(function () {
    //Add button click event
    $('#add').click(function () {
        //validation and add order items
        var isAllValid = true;
        if ($('#Name').val() == "") {
            isAllValid = false;
            $('#Name').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#Name').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#drpGender').val() == "Select") {
            isAllValid = false;
            $('#drpGender').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#drpGender').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#DOB').val().trim() == "" ) {
            isAllValid = false;
            $('#DOB').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#DOB').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#ContactNo').val().trim() == "" ) {
            isAllValid = false;
            $('#ContactNo').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#ContactNo').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            var $newRow = $('#mainrow').clone().removeAttr('id');
            $('.gender', $newRow).val($('#drpGender').val());
            //Replace add button with remove button
            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

            //remove id attribute from new clone row
            $('#Name,#drpGender,#DOB,#ContactNo,#add', $newRow).removeAttr('id');
            $('span.error', $newRow).remove();
            //append clone row
            $('#addNewMember').append($newRow);

            //clear select data
            $('#Name,#DOB,#ContactNo').val('');
            $('#drpGender').val('Select');
            $('#addNewMemberError').empty();
        }

    })

    //remove button click event
    $('#addNewMember').on('click', '.remove', function () {
        $(this).parents('tr').remove();
    });
    $('#exit').click(function () {
        window.location.href = "/Home/Index";
    });
    $('#submit').click(function () {
        var isAllValid = true;

        //validate order items
        $('#addNewMemberError').text('');
        var list = [];
        var errorItemCount = 0;
        $('#addNewMember tbody tr').each(function (index, ele) {
            debugger;
            var a = $('.name', this).val();
            var b = $('select.gender', this).val();
            var c = $('.dob', this).val();
            var d = $('.contactno', this).val();
            if (
                $('.name', this).val() == "" ||
                $('select.gender', this).val() == "Select" ||
                $('.dob', this).val() == "" ||
                $('.contactno', this).val() == "") {
                errorItemCount++;
                $(this).addClass('error');
            } else {
                var addNewMember = {
                    MemberName: $('.name', this).val(),
                    Gender: $('select.gender', this).val(),
                    DOB: $('.dob', this).val(),
                    ContactNo: $('.contactno', this).val(),
                }
                list.push(addNewMember);
            }
        })
        if (errorItemCount > 0) {
            $('#orderItemError').text(errorItemCount + " invalid entry in order item list.");
            isAllValid = false;
        }

        if (list.length == 0) {
            $('#orderItemError').text('At least 1 order item required.');
            isAllValid = false;
        }

        if ($('#TeamName').val().trim() == '') {
            $('#TeamName').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#TeamName').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#Description').val().trim() == '') {
            $('#Description').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#Description').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            var data = {
                teamName: $('#TeamName').val().trim(),
                description: $('#Description').val().trim(),
                teamMembers: list
            }

            $(this).val('Please wait...');

            $.ajax({
                type: 'POST',
                url: '/home/save',
                data: data,
                success: function (data) {
                    if (data.status) {
                        toastr.success('Team saved successfully!');
                        //here we will clear the form
                        list = [];
                        $('#TeamName,#Description').val('');
                        $('#addNewMember').empty();
                    }
                    else {
                        toastr.error('Something unexpected happened!');
                    }
                    $('#submit').val('Save');
                },
                error: function (error) {
                    console.log(error);
                    $('#submit').val('Save');
                }
            });
        }

    });
    $('#update').click(function () {
        var isAllValid = true;

        //validate order items
        $('#addNewMemberError').text('');
        var list = [];
        var errorItemCount = 0;
        $('#addNewMember tbody tr').each(function (index, ele) {
            debugger;
            var a = $('.name', this).val();
            var b = $('select.gender', this).val();
            var c = $('.dob', this).val();
            var d = $('.contactno', this).val();
            if (
                $('.name', this).val() == "" ||
                $('select.gender', this).val() == "Select" ||
                $('.dob', this).val() == "" ||
                $('.contactno', this).val() == "") {
                errorItemCount++;
                $(this).addClass('error');
            } else {
                var addNewMember = {
                    TeamId: $('#TeamId').val().trim(),
                    MemberName: $('.name', this).val(),
                    Gender: $('select.gender', this).val(),
                    DOB: $('.dob', this).val(),
                    ContactNo: $('.contactno', this).val(),
                }
                list.push(addNewMember);
            }
        })
        if (errorItemCount > 0) {
            $('#orderItemError').text(errorItemCount + " invalid entry in order item list.");
            isAllValid = false;
        }

        if (list.length == 0) {
            $('#orderItemError').text('At least 1 order item required.');
            isAllValid = false;
        }

        if ($('#TeamName').val().trim() == '') {
            $('#TeamName').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#TeamName').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#Description').val().trim() == '') {
            $('#Description').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#Description').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            var data = {
                teamId: $('#TeamId').val().trim(),
                teamName: $('#TeamName').val().trim(),
                description: $('#Description').val().trim(),
                teamMembers: list
            }

            $(this).val('Please wait...');

            $.ajax({
                type: 'POST',
                url: '/home/edit',
                data: data,
                success: function (data) {
                    if (data.status) {
                        toastr.success('Team update successfully!');
                       
                    }
                    else {
                        toastr.error('Something unexpected happened!');
                    }
                    $('#update').val('Update');
                },
                error: function (error) {
                    console.log(error);
                    $('#update').val('Update');
                }
            });
        }

    });
});

