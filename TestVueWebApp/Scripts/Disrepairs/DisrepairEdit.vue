<template>
    <div id="disrepair">
        <h1>Disrepair edit</h1>
        <p></p>
        <form :action="EditDisrepairUrl" method="post">
            <input type="hidden" name="FailureCd" :value="Disrepair.FailureCd"
            <div class="row">
                <div class="col-md-4">
                    <div class="text-danger"></div>
                    <div class="form-group">
                        <label for="FailureName" class="control-label">FailureName</label>
                        <input name="FailureName" class="form-control" :value="Disrepair.FailureName" />
                        <span asp-validation-for="FailureName" class="text-danger"></span>
                    </div>
                    <div class="form-group">
                        <input type="submit" value="Create" class="btn btn-primary" />
                    </div>
                </div>
            </div>
        </form>
    </div>

</template>

<script>
    export default {
        name: "disrepair-edit-component",
        props: {
            EditDisrepairUrl: String,
            Disrepair: Object
        }
    };
</script>