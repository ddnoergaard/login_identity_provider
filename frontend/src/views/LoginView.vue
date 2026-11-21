<script setup>
import { ref } from 'vue';

const emailInput = ref(null);
const passwordInput = ref(null);
const errorMsg = ref(null);
const errorBool = ref(false);

async function Login() {
    if (emailInput.value === null || passwordInput.value === null) {
        errorMsg.value = "Invalid email or password"
        errorBool.value = true;
    }
    console.log(emailInput.value)
    console.log(passwordInput.value)
}


</script>

<template>
    <div id="container">
        <div id="login-card">
            <div id="lc-text">
                <h1>Login</h1>
                <p>Lets get you sorted!</p>
            </div>
            <div id="input-container">
                <label for=""></label>
                <input type="email" placeholder="john@doe.com" v-model="emailInput">
                <input type="password" placeholder="&#9679;&#9679;&#9679;&#9679;&#9679;&#9679;&#9679;&#9679;&#9679;"
                    v-model="passwordInput">
            </div>
            <button @click="Login">Login</button>
        </div>
    </div>
</template>

<style scoped>
#container {
    width: 100dvw;
    height: 100dvh;
    display: flex;
    place-items: center;
    justify-content: center;
}

#login-card {
    display: flex;
    min-width: 20dvw;
    min-height: 40dvh;
    flex-direction: column;
    text-align: center;
    gap: 1rem;
    padding: 2rem;
    background-color: var(--bg);
    border-radius: 1rem;
    justify-content: space-evenly;
}

#lc-text {
    display: flex;
    flex-direction: column;
    gap: 0.5rem;
}

#input-container {
    display: flex;
    flex-direction: column;
    gap: 3rem;
    place-items: center;
}

input {
    height: 1.5rem;
    width: 75%;
    padding: 1rem;
    border: 1px solid transparent;
    border-radius: 0.5rem;
    outline: none;
    color: var(--bg);
}

input:focus {
    border-color: pink;
}

button {
    width: fit-content;
    place-self: center;
    padding: 0.5rem 1rem;
    color: var(--text);
    background-color: transparent;
    border: 1px solid var(--light-b);
    transition: .3s;
    cursor: pointer;
}

button:hover {
    background-color: var(--light-b);
    color: var(--bg);
}

@media (width < 1250px) {
    #login-card {
        width: 100dvw;
        height: 100dvh;
        padding: 0;
        border-radius: 0;
    }

}
</style>