function deleteStudent(id) {
    if (confirm("Bạn có chắc chắn muốn xóa ?")) {
        $.ajax({
            url: '/Student/Delete?id=' + id,
            type: 'DELETE',
            success: function (response) {
                alert('Delete success!');
                $('#' + id).remove();
            },
            error: function (err) {
                alert('Delete error!');
            }
        });
    }
}