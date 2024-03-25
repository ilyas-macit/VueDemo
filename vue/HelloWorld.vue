<template>
  <button @click="handleClick">Buton</button>
</template>

<script>
export default {
  name: "MyButton",

  props: {
    buttonText: {
      type: String,
      default: "Click me",
    },
  },

  methods: {
    handleClick() {
      alert("Button clicked!");
    },
  },
};
</script>

<style scoped>
/* Stil buraya */
</style>
