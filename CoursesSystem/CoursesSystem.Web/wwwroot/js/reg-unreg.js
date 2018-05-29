<script>
    $(function () {
        $('.btn-trigger').click(function () {

            const data = {
                'id': $(this).attr("parameter1"),
                'name': $(this).attr("parameter2"),
            };

            const buttonId = $(this).attr('id');
            console.log(buttonId);
            console.log(data.id);

            let postUrl;

            if (buttonId.startsWith('reg')) {
                postUrl = '/Courses/RegisterCourse';
            }
            else {
                postUrl = '/Courses/UnregisterCourse';
            }
            console.log(postUrl);

            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: postUrl,
                data: JSON.stringify(data),
                datatype: "json",
                success: function (result) {

                    if (buttonId.startsWith('reg')) {
                        console.log('reg');
                        $(`#${buttonId}`).css('visibility', 'hidden');
                        $(`#unregBtn-${data.id}`).css('visibility', 'visible');
                    }
                    else {
                        console.log('unreg');
                        $(`#unregBtn-${data.id}`).css('visibility', 'hidden');
                        $(`#regBtn-${data.id}`).css('visibility', 'visible');
                    }

                    $('#confirm-message').text(result).css({ 'color': 'green', 'font-weight': '500', 'font-size': 'large' }).show().delay(3000).fadeOut();
                },
                error: function (result) {
                    $('#confirm-message').text("Error: " + result).css({ 'color': 'red', 'font-weight': '500', 'font-size': 'large' }).show().delay(3000).fadeOut();
                }
            });
        });
    });
    </script>