for (var ele of document.getElementsByName("remove")) {
    ele.addEventListener("click", (e) => {
        if (confirm("delete") == false)
            e.preventDefault();
    })
}



for (let ele of document.getElementsByName("Edit"))
    ele.addEventListener("click", (e) => {    
        var Id = ele.id;

        $.ajax(
            {
                url: "/course/EditCourseModel/" + Id,
                success: function (r) {
                    document.getElementById("pa").innerHTML = r;
                    $("#launchModal").click();
                }
            }


        )
    });
