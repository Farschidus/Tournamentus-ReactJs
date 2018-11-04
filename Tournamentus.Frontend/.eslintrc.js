const OFF = 0;
const ERROR = 2;

module.exports = {
    plugins: ['ramda'],
    extends: ['react-app', 'airbnb', 'plugin:ramda/recommended'],
    rules: {
        indent: [
            'error',
            4,
            {
                SwitchCase: 1,
            },
        ],
        'max-len': OFF,
        'no-use-before-define': OFF,
        'no-shadow': OFF,
        'react/jsx-indent': [ERROR, 4],
        'react/jsx-indent-props': [ERROR, 4],
        'react/jsx-filename-extension': OFF,
        'react/require-default-props': OFF,
        'react/prop-types': OFF,
        'import/no-unresolved': OFF,
        'import/no-extraneous-dependencies': [
            'error',
            {
                devDependencies: [
                    'src/setupTests.js',
                    '**/*.test.js',
                    'prop-types',
                ],
            },
        ],
        'jsx-a11y/href-no-hash': OFF,
    },
};
