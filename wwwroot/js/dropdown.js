$(()=>{
    dropdownOptions.forEach(dp => {
        if(dp.isLinked){
            $(`#${dp.id}`).on('change',(e)=>{
                var target = e.target
                var selectedValue = $(target).val()
                loadData(dp.dataUrl, dp.linkedTo, selectedValue, dp.id)
            })
        }
    });

    function loadData(url,elementId,value,originatorId){
        var option = `<option value=0>Select ${elementId}</option>`

        $.ajax({
            url: url,
            crossDomain:true,
            success: (r)=>{
                r.forEach(data => {
                    if(data[`${originatorId}Id`]==value)
                        option = option + `<option value=${data.value}>${data.name}</option>`
                });

                $(`#${elementId}`).html("")
                $(`#${elementId}`).html(option)
            },
            error: (e)=>{
                console.log(e)
            }
        })
    }
})