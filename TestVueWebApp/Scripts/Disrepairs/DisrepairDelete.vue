<template>
    <div id="disrepair">
        <h1>Disrepair delete</h1>
        <h3>Are you sure you want to delete this?</h3>
        <dl class="row">
            <dt class="col-sm-2">
                <label>FailureName</label>
            </dt>
            <dd class="col-sm-10">
                {{Disrepair.FailureName}}
            </dd>
        </dl>
        <form :action="DeleteStreetUrl" method="post">
            <input type="hidden" name="FailureCd" :value="Disrepair.FailureCd"/>
            <input type="submit" value="Delete" class="btn btn-danger" /> |
            <a :href="IndexDisrepairUrl">Back to List</a>
        </form>

    </div>
</template>

<script>
    export default {
        name: "disrepair-delete-component",
        props: {
            DeleteDisrepairUrl: String,
            IndexDisrepairUrl: String,
            Disrepair: Object
        }
    };
</script>