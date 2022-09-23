<template>
    <div id="executor">
        <h1>Executors create</h1>
        <p></p>
        <form :action="CreateExecutorUrl" method="post">
            <div class="row">
                <div class="col-md-4">
                    <div class="text-danger"></div>
                    <div class="form-group">
                        <label for="Fio" class="control-label">Fio</label>
                        <input name="Fio" class="form-control" />
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
        name: "executor-create-component",
        props: {
            CreateExecutorUrl: String
        }
    };
</script>