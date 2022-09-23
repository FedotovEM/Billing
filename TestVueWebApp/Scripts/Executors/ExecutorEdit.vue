<template>
    <div id="executor">
        <h1>Executor edit</h1>
        <p></p>
        <form :action="EditExecutorUrl" method="post">
            <input type="hidden" name="ExecutorCd" :value="Executor.ExecutorCd"
            <div class="row">
                <div class="col-md-4">
                    <div class="text-danger"></div>
                    <div class="form-group">
                        <label for="Fio" class="control-label">Fio</label>
                        <input name="Fio" class="form-control" :value="Executor.Fio" />
                        <span asp-validation-for="Fio" class="text-danger"></span>
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
        name: "executor-edit-component",
        props: {
            EditExecutorUrl: String,
            Executor: Object
        }
    };
</script>