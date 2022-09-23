<template>
    <div id="executor">
        <h1>Executor delete</h1>
        <h3>Are you sure you want to delete this?</h3>
        <dl class="row">
            <dt class="col-sm-2">
                <label>Fio</label>
            </dt>
            <dd class="col-sm-10">
                {{Executor.Fio}}
            </dd>
        </dl>
        <form :action="DeleteExecutorUrl" method="post">
            <input type="hidden" name="ExecutorCd" :value="Executor.ExecutorCd"/>
            <input type="submit" value="Delete" class="btn btn-danger" /> |
            <a :href="IndexExecutorUrl">Back to List</a>
        </form>

    </div>
</template>

<script>
    export default {
        name: "executor-delete-component",
        props: {
            DeleteExecutorUrl: String,
            IndexExecutorUrl: String,
            Executor: Object
        }
    };
</script>