<template>
    <div id="executor">
        <h1>Executor details</h1>
        <dl class="row">
            <dt class="col-sm-2">
                <label>StreetName</label>
            </dt>
            <dd class="col-sm-10">
                {{Executor.Fio}}
            </dd>
        </dl>
        <div>
            <a :href="EditExecutorUrl+'/'+Executor.ExecutorCd">Edit</a> |
            <a :href="IndexExecutorUrl">Back to List</a>
        </div>
    </div>

</template>

<script>
    export default {
        name: "executor-details-component",
        props: {
            EditExecutorUrl: String,
            IndexExecutorUrl: String,
            Executor: Object
        }
    };
</script>