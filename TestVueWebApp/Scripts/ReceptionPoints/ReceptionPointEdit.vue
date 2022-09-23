<template>
    <div id="reception">
        <h1>ReceptionPoint edit</h1>
        <p></p>
        <form :action="EditReceptionUrl" method="post">
            <input type="hidden" name="ReceptionPointCd" :value="Reception.ReceptionPointCd"
            <div class="row">
                <div class="col-md-4">
                    <div class="text-danger"></div>
                    <div class="form-group">
                        <label for="ReceptionName" class="control-label">ReceptionName</label>
                        <input name="ReceptionName" class="form-control" :value="Reception.ReceptionName" />
                        <span asp-validation-for="ReceptionName" class="text-danger"></span>
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
        name: "edit-component",
        props: {
            EditReceptionUrl: String,
            Reception: Object
        }
    };
</script>